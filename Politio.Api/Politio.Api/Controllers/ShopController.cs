using Microsoft.AspNetCore.Mvc;
using Politio.Api.Data;
using Politio.Api.Services;

namespace Politio.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ShopController
{
    [HttpGet("Avatars")]
    public IEnumerable<string> GetAvatars()
        => Directory.EnumerateFiles("../../Politio/src/assets/avatars/").Select(f => Path.GetFileName(f)).ToList();

    [HttpGet("AvatarMysteryBoxes")]
    public List<Box> GetAvatarMysteryBoxes()
        => BoxService.AvatarMysteryBoxes;

    [HttpGet("WordMysteryBoxes")]
    public List<Box> GetWordMysteryBoxes()
        => BoxService.WordMysteryBoxes;

    [HttpGet("WordPacks")]
    public List<Box> GetWordPacks()
        => BoxService.WordPacks;

    [HttpGet("RandomAvatar")]
    public string GetRandomAvatar(string boxName)
        => BoxService.AvatarMysteryBoxes.Single(b => b.Name == boxName).GetRandomItem();

    [HttpGet("RandomWord")]
    public string GetRandomWord(string boxName)
        => BoxService.WordMysteryBoxes.Single(b => b.Name == boxName).GetRandomItem();
}
