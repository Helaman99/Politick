using Microsoft.AspNetCore.Mvc;
using Politick.Api.Services;
using Politick.Api.Data;

namespace Politick.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ShopController : ControllerBase
{
    private readonly ShopService _shopService;
    private readonly ILogger<ShopController> _logger;

    public ShopController(ShopService shopService, ILogger<ShopController> logger)
    {
        _shopService = shopService;
        _logger = logger;
    }

    [HttpGet("Avatars")]
    public IActionResult GetAvatars()
    {
        string[] imagePaths = _shopService.GetAvatarImages();

        List<string> imageUrls = new();
        foreach (string imagePath in imagePaths)
        {
            string imageName = Path.GetFileName(imagePath);
            var imageUrl = Url.Action("GetAvatarImage", new { imageName });
            imageUrls.Add(imageUrl);
        }

        return Ok(imageUrls);
    }

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
