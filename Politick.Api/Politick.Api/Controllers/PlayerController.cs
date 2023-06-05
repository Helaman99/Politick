using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Politick.Api.Services;
using Politick.Api.Data;
using System.Security.Claims;

namespace Politick.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PlayerController : ControllerBase
{
    private readonly PlayerService _playerService;
    private readonly ILogger<PlayerController> _logger;

    public PlayerController(PlayerService playerService, ILogger<PlayerController> logger)
    {
        _playerService = playerService;
        _logger = logger;
    }

    private string GetEmailFromClaims()
    {
        return User.Claims.First(e => e.Type == ClaimTypes.Email).Value;
    }

    [HttpGet("GetPlayer")]
    public async Task<Player> GetPlayerData() 
        => await _playerService.GetPlayerDataAsync(GetEmailFromClaims());

    [HttpPost("GetUnlockedAvatars")]
    public IActionResult GetUnlockedAvatars()
    {
        string[] imagePaths = _playerService.GetAvatarImages();

        List<string> imageUrls = new();
        foreach (string imagePath in imagePaths)
        {
            string imageName = Path.GetFileName(imagePath);
            var imageUrl = Url.Action("GetAvatarImage", new { imageName });
            if (imageUrl is not null)
                imageUrls.Add(imageUrl);
        }

        return Ok(imageUrls);
    }

    [HttpPost("UpdateCard")]
    public async Task UpdateCard([FromBody] PlayerCard playerCard) 
        => await _playerService.UpdateCardAsync(GetEmailFromClaims(), playerCard);

    [HttpPost("AddCoins")]
    public async Task AddCoinsAsync(int amount) 
        => await _playerService.AddCoinsAsync(GetEmailFromClaims(), amount);

    [HttpPost("RemoveCoins")]
    public async Task RemoveCoins(int amount) 
        => await _playerService.RemoveCoinsAsync(GetEmailFromClaims(), amount);

    [HttpPost("AddGame")]
    public async Task AddGameAsync()
        => await _playerService.AddGameAsync(GetEmailFromClaims());

    [HttpPost("AddTitleFirstWords")]
    public async Task AddTitleFirstWordsAsync(string[] newWords)
        => await _playerService.AddTitleFirstWordsAsync(GetEmailFromClaims(), newWords);

    [HttpPost("AddTitleSecondWords")]
    public async Task AddTitleSecondWordsAsync(string[] newWords)
        => await _playerService.AddTitleSecondWordsAsync(GetEmailFromClaims(), newWords);

    [HttpPost("UpdateStanding")]
    public async Task UpdateStandingAsync(string newStanding)
        => await _playerService.UpdateStandingAsync(GetEmailFromClaims(), newStanding);

    [HttpPost("AddAvatar")]
    public async Task AddAvatarAsync(string newAvatar)
        => await _playerService.AddAvatarAsync(GetEmailFromClaims(), newAvatar);

    [HttpPost("ChangeTheme")]
    public async Task ChangeThemeAsync(string newTheme)
        => await _playerService.ChangeThemeAsync(GetEmailFromClaims(), newTheme);
}
