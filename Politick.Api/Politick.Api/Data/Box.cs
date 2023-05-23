namespace Politick.Api.Data;

public class Box
{
    public string Name { get; set; }
    public string[] Contents { get; set; }
    public int Price { get; set; }

    public Box(string name, string[] contents, int price)
    {
        Name = name;
        Contents = contents;
        Price = price;
    }

    public string GetRandomItem()
    {
        Random rm = new();
        return Contents[rm.Next(0, Contents.Length - 1)];
    }
}
