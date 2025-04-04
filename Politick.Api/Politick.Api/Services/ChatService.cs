﻿using Politick.Api.Data;
using System.Numerics;

namespace Politick.Api.Services;

public class ChatService
{
    private List<List<Room>> TopicRoomsLists { get; }
    private List<Room> RoomsInProgress { get; }
    private int NextRoomId { get; set; }
    private static readonly object _lock = new();

    public ChatService()
    {
        TopicRoomsLists = new List<List<Room>>(TopicService.TopicCount);
        for (int i = 0; i < TopicService.TopicCount; i++)
            TopicRoomsLists.Add(new List<Room>());

        RoomsInProgress = new List<Room>();
        NextRoomId = 1;
    }

    public Opponent AssignRoomId(Opponent player)
    {
        lock (_lock)
        {
            List<Room> availableRooms = TopicRoomsLists[player.Topic];
            foreach (Room room in availableRooms)
            {
                if (room.Side != player.Side && room.PlayersWaiting < 2)
                {
                    room.PlayersWaiting = 2;
                    player.ChatRoomId = room.ChatRoomId;
                    room.Opponents.Add(player);
                    return new Opponent("", player.Avatar, player.Title, player.Topic, player.Side, player.ChatRoomId);
                }
            }
            string newRoomId = NextRoomId++.ToString();
            player.ChatRoomId = newRoomId;
            availableRooms.Add(new Room(player.Side, player, newRoomId));
            return new Opponent("", player.Avatar, player.Title, player.Topic, player.Side, newRoomId);
            // New Opponent object that is returned has an empty email to protect PII
        }
    }

    public int AddPlayerToRoom(string connectionId, string chatRoomId)
    {
        Room? room = null;
        lock (_lock)
        {
            foreach (List<Room> list in TopicRoomsLists)
            {
                room = list.Where(p => p.ChatRoomId == chatRoomId).SingleOrDefault();
                if (room is not null && room.PlayersJoined < 2)
                {
                    room.ConnectionIds.Add(connectionId);
                    room.PlayersJoined++;
                    return room.PlayersJoined;
                }
            }
        }
        return 0;
    }

    public bool StartRoom(string chatRoomId)
    {
        Room? room;
        lock (_lock)
        {
            foreach (List<Room> list in TopicRoomsLists)
            {
                room = list.Where(r => r.ChatRoomId == chatRoomId).SingleOrDefault();
                if (room is not null)
                {
                    RoomsInProgress.Add(room);
                    list.Remove(room);
                    return true;
                }
            }
        }
        return false;
    }

    public Opponent GetOpponent(Opponent thisPlayer)
    {
        if (thisPlayer is null) { throw new ArgumentNullException(nameof(thisPlayer)); }

        Room? room = RoomsInProgress.Find(r => r.ChatRoomId == thisPlayer.ChatRoomId);
        if (room is not null && room.Opponents.Count == 2)
        {
            if (room.Opponents[0].Email == thisPlayer.Email)
            {
                return new Opponent("", room.Opponents[1].Avatar, 
                                        room.Opponents[1].Title, 
                                        room.Opponents[1].Topic, 
                                        room.Opponents[1].Side, 
                                        room.Opponents[1].ChatRoomId);
            }
            return new Opponent("", room.Opponents[0].Avatar,
                                    room.Opponents[0].Title,
                                    room.Opponents[0].Topic,
                                    room.Opponents[0].Side,
                                    room.Opponents[0].ChatRoomId);
        }
        throw new NullReferenceException(nameof(room));
    }

    public bool EndGame(string chatRoomId)
    {
        Room? room;
        lock (_lock) 
        { 
            room = RoomsInProgress.Find(r => r.ChatRoomId == chatRoomId);
            if (room is not null)
            {
                RoomsInProgress.Remove(room);
                return true;
            }
        }
        return false;
    }

    public bool ValidateConnection(string chatRoomId, string connectionId)
    {
        lock (_lock)
        {
            Room? room = RoomsInProgress.Find(r => r.ChatRoomId == chatRoomId);
            if (room is not null && room.ConnectionIds.Contains(connectionId))
                return true;
            foreach (List<Room> list in TopicRoomsLists)
            {
                room = list.Find(p => p.ChatRoomId == chatRoomId);
                if (room is not null)
                    return true;
            }
        }
        

        return false;
    }

    public string DisconnectRoom(string connectionId)
    {
        Room? room;
        lock (_lock)
        {
            foreach (List<Room> list in TopicRoomsLists)
            {
                room = list.Find(p => p.ConnectionIds.Contains(connectionId));
                if (room is not null)
                {
                    list.Remove(room);
                    return room.ChatRoomId;
                }
            }
            room = RoomsInProgress.Find(r => r.ConnectionIds.Contains(connectionId));
            if (room is not null)
            {
                RoomsInProgress.Remove(room);
                return room.ChatRoomId;
            }
            return "-1";
        }
    }

    public int GetRoomsInProgress()
        => RoomsInProgress.Count;
}
