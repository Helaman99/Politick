using Microsoft.AspNetCore.Mvc;
using Politio.Api.Data;
using Politio.Api.Services;

namespace Politio.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController
{
    private readonly PlayerService _playerService;

    public PlayerController(PlayerService playerService)
    {
        _playerService = playerService;
    }

    [HttpGet]
    public bool Login(string email, string password)
    {
        return _playerService.Login(email, password);
    }

    [HttpGet]
    public string GetPlayerData(string email)
    {
        return _playerService.GetPlayerData(email);
    }

    [HttpPost]
    public void UpdateCard(string email, string avatar, string title)
    {
        _playerService.UpdateCard(email, avatar, title);
    }

    [HttpPost]
    public void AddCoins(string email, int amount)
    {
        _playerService.AddCoins(email, amount);
    }

    [HttpPost]
    public void RemoveCoins(string email, int amount)
    {
        _playerService.RemoveCoins(email, amount);
    }

    [HttpPost]
    public void UpdatePassword(string email, string password)
    {
        _playerService.UpdatePassword(email, password);
    }
}
