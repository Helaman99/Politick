namespace Politick.Api.Data;

public class Side
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Standing { get; set; }
    public Side(string title, string description, string standing)
    {
        Title = title;
        Description = description;
        Standing = standing;
    }
}
