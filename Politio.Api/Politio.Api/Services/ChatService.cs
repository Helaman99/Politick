﻿using Politio.Api.Data;
using System.Numerics;

namespace Politio.Api.Services;

public class ChatService
{
    private List<List<Room>> TopicRoomsLists { get; }
    private List<Room> RoomsInProgress { get; }
    private int NextRoomId { get; set; }
    private readonly object _lock = new object();

    public ChatService()
    {
        TopicRoomsLists = new List<List<Room>>(TopicService.TopicCount);
        for (int i = 0; i < TopicService.TopicCount; i++)
            TopicRoomsLists.Add(new List<Room>());

        RoomsInProgress = new List<Room>();
        NextRoomId = 1;
    }

    public string GetRoomId(int id, int topic, int side)
    {
        lock (_lock)
        {
            List<Room> availableRooms = TopicRoomsLists[topic];
            foreach (Room room in availableRooms)
            {
                if (room.Side != side && room.PlayersWaiting < 2)
                {
                    room.PlayersWaiting = 2;
                    room.PlayerIds.Add(id);
                    return room.ChatRoomId;
                }
            }
            string newRoomId = NextRoomId++.ToString();
            availableRooms.Add(new Room(side, id, newRoomId));
            return newRoomId;
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
        Room? room = RoomsInProgress.Find(r => r.ChatRoomId == chatRoomId);
        if (room is not null && room.ConnectionIds.Contains(connectionId))
            return true;

        return false;
    }

    public bool DeleteRoom(int playerId)
    {
        Room? room = null;
        lock (_lock)
        {
            foreach (List<Room> list in TopicRoomsLists)
            {
                room = list.Where(p => p.PlayerIds.Contains(playerId)).SingleOrDefault();
                if (room is not null)
                {
                    list.Remove(room);
                    return true;
                }
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
}
