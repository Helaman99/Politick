using Microsoft.AspNetCore.Mvc;
using Politio.Api.Services;

namespace Politio.Api.Controllers;

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

    [HttpPost("UpdateCard")]
    public void UpdateCard(int id, string avatar, string title) 
        => _playerService.UpdateCard(id, avatar, title);

    [HttpPost("Add")]
    public void AddCoins(int id, int amount) 
        => _playerService.AddCoins(id, amount);

    [HttpPost("Remove")]
    public void RemoveCoins(int id, int amount) 
        => _playerService.RemoveCoins(id, amount);

    [HttpPost("Update")]
    public void UpdatePassword(int id, string password) 
        => _playerService.UpdatePassword(id, password);

    [HttpPost("Activate")]
    public bool ActivatePlayer(int id, int code) 
        => _playerService.ActivatePlayer(id, code);
}
