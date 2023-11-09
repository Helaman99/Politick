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
        new("Gloomy", new[] { "Gloomy", "Unhappy", "Depressed", "Rainy", "Overcast", "Pessimistic" }, 12),
        new("Happy", new[] { "Sunny", "Cheerful", "Hopeful", "Optimistic", "Bubbly" }, 10),
        new("Military Ranks", new[] { "Corporal", "Sergeant", "Lieutenant", "Captain", "Major", "Colonel", "Commander", "General" }, 16),
        new("Textures", new[] { "Sticky", "Slimy", "Smooth", "Rough", "Bouncy", "Hard", "Soft" }, 14),
        new("Flavors", new[] { "Cheesy", "Salty", "Sour", "Tart", "Sweet", "Savory", "Spicy", "Bitter" }, 16),
        new("Extrovert", new[] { "Social", "Inquisitive", "Adventurous", "Extroverted" }, 8),
        new("Introvert", new[] { "Anti-Social", "Uninterested", "Indifferent", "Unadventurous", "Introverted" }, 10),
        new("Emotions", new[] { "Annoyed", "Fearful", "Nervous", "Curious", "Intrigued", "Determined", "Confused" }, 14),
    };

    public static readonly List<Box> SecondWordPacks = new()
    {
        new("Fruit", new[] { "Banana", "Orange", "Apple", "Grape", "Pineapple", "Strawberry", "Watermelon" }, 14),
        new("Nature", new[] { "Tree", "Bush", "Leaf", "Plant", "Rock", "Boulder" }, 12),
        new("Crawly Things", new[] { "Ant", "Bumblebee", "Ladybug", "Tarantula", "Stinkbug", "Butterfly", "Caterpillar" }, 14),
        new("Military Equipment", new[] { "M1A1 Abrams", "Battleship", "Destroyer", "Missile", "Drone", "A-10 Warthog", "AC-130" }, 14),
        new("Transportation", new[] { "Bus", "Car", "Train", "Truck", "Semi", "Sportscar", "ATV" }, 14),
    };
}
