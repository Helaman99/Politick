using Politio.Api.Data;
namespace Politio.Api.Services;

public static class BoxService
{
    public static readonly List<Box> AvatarMysteryBoxes = new()
    {
        new("Avatar Mystery Box 1", new[] { "path1", "path2" }, 5),
        new("Themed Avatars", new[] { "path1", "path2" }, 5),
    };

    public static readonly List<Box> WordMysteryBoxes = new()
    {
        new("Themed Words", new[] { "word1", "word2" }, 5),
        new("Themed Words", new[] { "word1", "word2" }, 5),
    };

    public static readonly List<Box> WordPacks = new()
    {
        new("Themed Words", new[] { "word1", "word2" }, 5),
        new("Themed Words", new[] { "word1", "word2" }, 5),
    };
}
