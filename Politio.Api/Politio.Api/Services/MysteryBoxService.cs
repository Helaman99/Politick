using Politio.Api.Data;
namespace Politio.Api.Services;

public class MysteryBoxService
{
    public readonly MysteryBox[] MysteryBoxes = new MysteryBox[]
    {
        new("Themed Avatars", new[] { "path1", "path2" }),
        new("Themed Avatars", new[] { "path1", "path2" }),
    };
}
