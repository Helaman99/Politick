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

    [HttpGet("SignUp")]
    public async Task<bool> SignUp(string email, string password)
        => await _playerService.SignUp(email, password);

    [HttpGet("Login")]
    public int Login(string email, string password) 
        => _playerService.Login(email, password);

    [HttpGet("GetPlayer")]
    public string GetPlayerData(int id) 
        => _playerService.GetPlayerData(id);

    [HttpGet("IsActivated")]
    public bool IsActivated(int id) 
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
            imageUrls.Add(imageUrl);
        }

        return Ok(imageUrls);
    }

    [HttpPost("UpdateCard")]
    public void UpdateCard(int id, string avatar, string title) 
        => _playerService.UpdateCard(id, avatar, title);

    [HttpPost("AddCoins")]
    public void AddCoins(int id, int amount) 
        => _playerService.AddCoins(id, amount);

    [HttpPost("RemoveCoins")]
    public void RemoveCoins(int id, int amount) 
        => _playerService.RemoveCoins(id, amount);

    [HttpPost("Update")]
    public void UpdatePassword(int id, string password) 
        => _playerService.UpdatePassword(id, password);

    [HttpPost("Activate")]
    public bool ActivatePlayer(int id, int code) 
        => _playerService.ActivatePlayer(id, code);

    [HttpPost("AddTitleFirstWords")]
    public void AddTitleFirstWords(int id, string[] newWords)
        => _playerService.AddTitleFirstWords(id, newWords);

    [HttpPost("AddTitleSecondWords")]
    public void AddTitleSecondWords(int id, string[] newWords)
        => _playerService.AddTitleSecondWords(id, newWords);

    [HttpPost("UpdateStanding")]
    public void UpdateStanding(int id, string newStanding)
        => _playerService.UpdateStanding(id, newStanding);

    [HttpPost("AddAvatar")]
    public void AddAvatar(int id, string newAvatar)
        => _playerService.AddAvatar(id, newAvatar);
}
