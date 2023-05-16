using Politio.Api.Data;
using System.Numerics;

namespace Politio.Api.Services;

public class ChatService
{
    private List<List<AvailableRoom>> TopicRoomsLists { get; }
    private int NextRoomId { get; set; }
    private readonly object _lock = new object();

    public ChatService()
    {
        TopicRoomsLists = new List<List<AvailableRoom>>(TopicService.TopicCount);
        for (int i = 0; i < TopicService.TopicCount; i++)
            TopicRoomsLists.Add(new List<AvailableRoom>());

        NextRoomId = 1;
    }

    public string GetRoomId(int id, int topic, int side)
    {
        lock (_lock)
        {
            List<AvailableRoom> availableRooms = TopicRoomsLists[topic];
            foreach (AvailableRoom room in availableRooms)
            {
                if (room.Side != side && room.PlayersWaiting < 2)
                {
                    room.PlayersWaiting = 2;
                    return room.ChatRoomId;
                }
            }
            string newRoomId = NextRoomId++.ToString();
            availableRooms.Add(new AvailableRoom(side, id, newRoomId));
            return newRoomId;
        }
    }

    public int AddPlayerToRoom(string chatRoomId)
    {
        AvailableRoom? room = null;
        lock (_lock)
        {
            foreach (List<AvailableRoom> list in TopicRoomsLists)
            {
                room = list.Where(p => p.ChatRoomId == chatRoomId).SingleOrDefault();
                if (room is not null)
                {
                    if (room.PlayersJoined < 2)
                        room.PlayersJoined++;
                    if (room.PlayersJoined == 2)
                        list.Remove(room);
                    return room.PlayersJoined;
                }
            }
        }
        return 0;
    }

    public bool DeleteRoom(int playerId)
    {
        AvailableRoom? room = null;
        lock (_lock)
        {
            foreach (List<AvailableRoom> list in TopicRoomsLists)
            {
                room = list.Where(p => p.InitialPlayerId == playerId).SingleOrDefault();
                if (room is not null)
                {
                    list.Remove(room);
                    return true;
                }
            }
        }
        return false;
    }
}
