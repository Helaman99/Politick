namespace Politio.Api.Data;

public class Side
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Side(string title, string description)
    {
        Title = title;
        Description = description;
    }
}
