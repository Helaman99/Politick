namespace Politio.Api.Data;

public class MysteryBox
{
    public string Name { get; set; }
    public string[] Contents { get; set; }

    public MysteryBox(string name, string[] contents)
    {
        Name = name;
        Contents = contents;
    }

    public string GetRandomItem()
    {
        Random rm = new Random();
        return Contents[rm.Next(0, Contents.Length - 1)];
    }
}
