namespace Politio.Api.Data;

public class Topic
{
    public readonly string Title;
    public readonly string Description;
    public readonly string Image;
    public readonly Side[] Sides;

    public Topic(string title, string description, string image, Side[] sides)
    {
        Title = title;
        Description = description;
        Image = image;
        Sides = sides;
    }
}
