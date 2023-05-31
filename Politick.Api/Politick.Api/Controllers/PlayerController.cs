using Microsoft.AspNetCore.Mvc;
using Politick.Api.Services;

namespace Politick.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly PlayerService _playerService;
    private readonly ILogger<PlayerController> _logger;

    public PlayerController(PlayerService playerService, ILogger<PlayerController> logger)
    {
        _playerService = playerService;
        _logger = logger;
    }

    [HttpGet("GetPlayer")]
    public string GetPlayerData(string id) 
        => _playerService.GetPlayerData(id);

    [HttpGet("IsActivated")]
    public bool IsActivated(string id) 
        => _playerService.IsActivated(id);

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
    public void UpdateCard(string id, string avatar, string title) 
        => _playerService.UpdateCard(id, avatar, title);

    [HttpPost("AddCoins")]
    public void AddCoins(string id, int amount) 
        => _playerService.AddCoins(id, amount);

    [HttpPost("RemoveCoins")]
    public void RemoveCoins(string id, int amount) 
        => _playerService.RemoveCoins(id, amount);

    [HttpPost("Activate")]
    public bool ActivatePlayer(string id, int code) 
        => _playerService.ActivatePlayer(id, code);

    [HttpPost("AddTitleFirstWords")]
    public void AddTitleFirstWords(string id, string[] newWords)
        => _playerService.AddTitleFirstWords(id, newWords);

    [HttpPost("AddTitleSecondWords")]
    public void AddTitleSecondWords(string id, string[] newWords)
        => _playerService.AddTitleSecondWords(id, newWords);

    [HttpPost("UpdateStanding")]
    public void UpdateStanding(string id, string newStanding)
        => _playerService.UpdateStanding(id, newStanding);

    [HttpPost("AddAvatar")]
    public void AddAvatar(string id, string newAvatar)
        => _playerService.AddAvatar(id, newAvatar);
}
