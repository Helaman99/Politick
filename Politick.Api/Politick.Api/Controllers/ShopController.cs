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
    public List<string> GetAvatars()
        => _shopService.GetAvatarImages();

    [HttpGet("Avatar/{filename}")]
    public IActionResult GetAvatarImage(string filename)
    {
        string imagePath = _shopService.GetAvatarImage(filename);
        if (!System.IO.File.Exists(imagePath))
            return NotFound();

        byte[] imageData = System.IO.File.ReadAllBytes(imagePath);
        return File(imageData, "image/png");
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
