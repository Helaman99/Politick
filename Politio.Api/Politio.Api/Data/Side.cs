namespace Politio.Api.Data;

public class Side
{
    public readonly string Title;
    public readonly string Description;
    public Side(string title, string description)
    {
        Title = title;
        Description = description;
    }
}
