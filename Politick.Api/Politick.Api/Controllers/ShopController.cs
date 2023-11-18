using Microsoft.AspNetCore.Mvc;
using Politick.Api.Services;
using Politick.Api.Data;
using Microsoft.AspNetCore.Authorization;
using Politick.Api.Models;

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

    [HttpGet("BasicAvatars")]
    [Authorize]
    public List<string> GetBasicAvatars()
        => _shopService.GetBasicAvatarImages();

    [HttpGet("PremiumAvatars")]
    [Authorize]
    public List<string> GetPremiumAvatars()
        => _shopService.GetPremiumAvatarImages();

    [HttpGet("Avatar/Basic/{filename}")]
    public IActionResult GetBasicAvatarImage(string filename)
    {
        string imagePath = _shopService.GetAvatarImage("/Basic/" + filename);
        if (!System.IO.File.Exists(imagePath))
            return NotFound();

        byte[] imageData = System.IO.File.ReadAllBytes(imagePath);
        return File(imageData, "image/png");
    }

    [HttpGet("Avatar/Premium/{filename}")]
    public IActionResult GetPremiumAvatarImage(string filename)
    {
        string imagePath = _shopService.GetAvatarImage("/Premium/" + filename);
        if (!System.IO.File.Exists(imagePath))
            return NotFound();

        byte[] imageData = System.IO.File.ReadAllBytes(imagePath);
        return File(imageData, "image/png");
    }

    [HttpGet("AvatarMysteryBoxes")]
    [Authorize]
    public List<Box> GetAvatarMysteryBoxes()
        => BoxService.AvatarMysteryBoxes;

    [HttpGet("WordMysteryBoxes")]
    [Authorize]
    public List<Box> GetWordMysteryBoxes()
        => BoxService.WordMysteryBoxes;

    [HttpGet("FirstWordPacks")]
    [Authorize]
    public List<Box> GetFirstWordPacks()
        => BoxService.FirstWordPacks;

    [HttpGet("SecondWordPacks")]
    [Authorize]
    public List<Box> GetSecondWordPacks()
        => BoxService.SecondWordPacks;

    [HttpGet("RandomAvatar")]
    [Authorize]
    public string GetRandomAvatar(string boxName)
        => BoxService.AvatarMysteryBoxes.Single(b => b.Name == boxName).GetRandomItem();

    [HttpGet("RandomWord")]
    [Authorize]
    public string GetRandomWord(string boxName)
        => BoxService.WordMysteryBoxes.Single(b => b.Name == boxName).GetRandomItem();

    [HttpGet("CoinPacks")]
    [Authorize]
    public List<CoinPack> GetCoinPacks()
        => ShopService.CoinPacks;

    [HttpPost("VerifyCoinPack")]
    [Authorize]
    public bool VerifyCoinPack(CoinPack coinPack)
        => _shopService.VerifyCoinPack(coinPack);
}
