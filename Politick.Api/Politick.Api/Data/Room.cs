namespace Politick.Api.Data;

public class Room
{
    public int Side { get; set; }
    public List<int> PlayerIds { get; set; }
    public List<string> ConnectionIds { get; set; }
    public string ChatRoomId { get; set; }
    public int PlayersWaiting { get; set; }
    public int PlayersJoined { get; set; }

    public Room(int side, int firstPlayerId, string chatRoomId)
    {
        Side = side;
        PlayerIds = new List<int> { firstPlayerId };
        ConnectionIds = new List<string>();
        ChatRoomId = chatRoomId;
        PlayersWaiting = 1;
        PlayersJoined = 0;
    }
}