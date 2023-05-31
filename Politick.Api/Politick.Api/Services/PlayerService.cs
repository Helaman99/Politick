using Microsoft.EntityFrameworkCore;
using Politick.Api.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Politick.Api.Services;

public class PlayerService
{
    private readonly AppDbContext _db;
    public PlayerService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Player> GetPlayerAsync(string id) 
        => await _db.Players.SingleAsync(p => p.Id == id);

    public string GetPlayerData(string id) 
        =>  GetPlayerAsync(id).Result.GetData();

    public bool IsActivated(string id) 
        => GetPlayerAsync(id).Result.Activation == 0;

    public bool ActivatePlayer(string id, int code) 
        => GetPlayerAsync(id).Result.Activate(code);

    public string[] GetAvatarImages()
        => Directory.GetFiles("../Assets/Avatars");

    public void UpdateCard(string id, string avatar, string title)
    {
        Player player = GetPlayerAsync(id).Result;
        player.Avatar = avatar;
        player.Title = title;
        _db.SaveChangesAsync();
    }

    public void AddCoins(string id, int amount)
    {
        Player player = GetPlayerAsync(id).Result;
        player.CoinsTotal += amount;
        _db.SaveChangesAsync();
    }

    public void RemoveCoins(string id, int amount)
    {
        Player player = GetPlayerAsync(id).Result;
        player.CoinsTotal -= amount;
        _db.SaveChangesAsync();
    }

    public void AddTitleFirstWords(string id, string[] newWords)
    {
        Player player = GetPlayerAsync(id).Result;
        player.AddTitleFirstWords(newWords);
        _db.SaveChangesAsync();
    }

    public void AddTitleSecondWords(string id, string[] newWords)
    {
        Player player = GetPlayerAsync(id).Result;
        player.AddTitleSecondWords(newWords);
        _db.SaveChangesAsync();
    }

    public void UpdateStanding(string id, string newStanding)
    {
        Player player = GetPlayerAsync(id).Result;
        switch (newStanding.ToLower())
        {
            case "authoritarian":
                    player.IncAuthoritarian(); break;
            case "left":
                    player.IncLeft(); break;
            case "libertarian":
                    player.IncLibertarian(); break;
            case "right":
                    player.IncRight(); break;
        }
        _db.SaveChangesAsync();
    }

    public void AddAvatar(string id, string avatar)
    {
        Player player = GetPlayerAsync(id).Result;
        player.AddAvatar(avatar);
        _db.SaveChangesAsync();
    }
}
