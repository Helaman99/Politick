namespace Politio.Api.Data;

public class AvailableRoom
{
    public int Side { get; set; }
    public int InitialPlayerId { get; set; }
    public string ChatRoomId { get; set; }
    public int PlayersWaiting { get; set; }
    public int PlayersJoined { get; set; }

    public AvailableRoom(int side, int playerId, string chatRoomId)
    {
        Side = side;
        InitialPlayerId = playerId;
        ChatRoomId = chatRoomId;
        PlayersWaiting = 1;
        PlayersJoined = 0;
    }
}