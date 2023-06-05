namespace Politick.Api.Data;

public class Opponent
{
    public string Email { get; set; }
    public string Avatar { get; set; }
    public string Title { get; set; }
    public int Topic { get; set; }
    public int Side { get; set; }
    public string ChatRoomId { get; set; }

    public Opponent(string email, string avatar, string title, int topic, int side, string chatRoomId)
    {
        Email = email;
        Avatar = avatar;
        Title = title;
        Topic = topic;
        Side = side;
        ChatRoomId = chatRoomId;
    }
}
