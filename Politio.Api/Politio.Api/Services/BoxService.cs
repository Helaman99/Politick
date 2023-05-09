using Politio.Api.Data;
namespace Politio.Api.Services;

public static class BoxService
{
    public static readonly List<Box> AvatarMysteryBoxes = new List<Box>
    {
        new("Avatar Mystery Box 1", new[] { "path1", "path2" }, 5),
        new("Themed Avatars", new[] { "path1", "path2" }, 5),
    };

    public static readonly List<Box> WordMysteryBoxes = new List<Box>
    {
        new("Themed Words", new[] { "word1", "word2" }, 5),
        new("Themed Words", new[] { "word1", "word2" }, 5),
    };

    public static readonly List<Box> WordPacks = new List<Box>
    {
        new("Themed Words", new[] { "word1", "word2" }, 5),
        new("Themed Words", new[] { "word1", "word2" }, 5),
    };
}
