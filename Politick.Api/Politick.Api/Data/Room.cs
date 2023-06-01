namespace Politick.Api.Data;

public class Room
{
    public int Side { get; set; }
    public List<Opponent> Opponents { get; set; }
    public List<string> ConnectionIds { get; set; }
    public string ChatRoomId { get; set; }
    public int PlayersWaiting { get; set; }
    public int PlayersJoined { get; set; }

    public Room(int side, Opponent firstOpponent, string chatRoomId)
    {
        Side = side;
        Opponents = new List<Opponent> { firstOpponent };
        ConnectionIds = new List<string>();
        ChatRoomId = chatRoomId;
        PlayersWaiting = 1;
        PlayersJoined = 0;
    }
}