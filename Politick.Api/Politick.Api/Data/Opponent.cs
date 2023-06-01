namespace Politick.Api.Data;

public class Opponent
{
    public int Id { get; set; }
    public string Avatar { get; set; }
    public string Title { get; set; }
    public int Topic { get; set; }
    public int Side { get; set; }
    public string ChatRoomId { get; set; }

    public Opponent(int id, string avatar, string title, int topic, int side, string chatRoomId)
    {
        Id = id;
        Avatar = avatar;
        Title = title;
        Topic = topic;
        Side = side;
        ChatRoomId = chatRoomId;
    }
}
