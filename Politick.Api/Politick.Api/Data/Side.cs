namespace Politick.Api.Data;

public class Side
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string[] Standings { get; set; }
    public Side(string title, string description, string[] standings)
    {
        Title = title;
        Description = description;
        Standings = standings;
    }
}
