namespace Politick.Api.Data;

public class Opponent
{
    public int Id { get; set; }
    public string Avatar { get; set; }
    public string Title { get; set; }

    public Opponent(int id, string avatar, string title)
    {
        Id = id;
        Avatar = avatar;
        Title = title;
    }
}
