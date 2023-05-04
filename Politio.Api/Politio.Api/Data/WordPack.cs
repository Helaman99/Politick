namespace Politio.Api.Data;

public class WordPack
{
    public string Name { get; set; }
    public string[] Words { get; set; }

    public WordPack(string name, string[] words)
    {
        Name = name;
        Words = words;
    }
}
