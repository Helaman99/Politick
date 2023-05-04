﻿using Microsoft.AspNetCore.Mvc;
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

    [HttpGet("Login")]
    public int Login(string email, string password)
    {
        return _playerService.Login(email, password);
    }

    [HttpGet("GetPlayer")]
    public string GetPlayerData(int id)
    {
        return _playerService.GetPlayerData(id);
    }

    [HttpPost("UpdateCard")]
    public void UpdateCard(int id, string avatar, string title)
    {
        _playerService.UpdateCard(id, avatar, title);
    }

    [HttpPost("Add")]
    public void AddCoins(int id, int amount)
    {
        _playerService.AddCoins(id, amount);
    }

    [HttpPost("Remove")]
    public void RemoveCoins(int id, int amount)
    {
        _playerService.RemoveCoins(id, amount);
    }

    [HttpPost("Update")]
    public void UpdatePassword(int id, string password)
    {
        _playerService.UpdatePassword(id, password);
    }
}
