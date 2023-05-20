using Politick.Api.Data;
namespace Politick.Api.Services;

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

    public static readonly List<Box> FirstWordPacks = new()
    {
        new("Military Ranks", new[] { "Colonel", "Captain", "Commander", "General" }, 4),
        new("Gloomy", new[] { "Gloomy", "Unhappy", "Depressed", "Rainy", "Overcast" }, 5),
    };

    public static readonly List<Box> SecondWordPacks = new()
    {
        new("Fruit", new[] { "Orange", "Apple", "Grape", "Pineapple", "Strawberry" }, 5),
        new("Military Equipment", new[] { "M1A1 Abrams", "Battleship", "Battlecruiser", "Missle", "Drone", "A-10 Warthog", "AC-130" }, 7),
    };
}
