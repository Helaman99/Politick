namespace Politio.Api.Data;

public class Topic
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public Side[] Sides { get; set; }

    public Topic(string title, string description, string image, Side[] sides)
    {
        Title = title;
        Description = description;
        Image = image;
        Sides = sides;
    }
}
