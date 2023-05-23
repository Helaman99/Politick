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

    public async Task<Player?> GetPlayerAsync(string email) 
        => await _db.Players.SingleOrDefaultAsync(p => p.Email == email);

    public async Task<Player> GetPlayerAsync(int id) 
        => await _db.Players.SingleAsync(p => p.Id == id);

    public string GetPlayerData(int id) 
        =>  GetPlayerAsync(id).Result.GetData();

    public async Task<bool> SignUp(string email, string password)
    {
        if (GetPlayerAsync(email) == null)
        {
            Player newPlayer = new (email, password);
            await _db.AddAsync(newPlayer);
            await _db.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public int Login(string email, string password)
    {
        Player? player = GetPlayerAsync(email).Result;
        if (player is not null && player.CheckPassword(password))
            return player.Id;
        return -1;
    }

    public bool IsActivated(int id) 
        => GetPlayerAsync(id).Result.Activation == 0;

    public bool ActivatePlayer(int id, int code) 
        => GetPlayerAsync(id).Result.Activate(code);

    public string[] GetAvatarImages()
        => Directory.GetFiles("../Assets/Avatars");

    public void UpdateCard(int id, string avatar, string title)
    {
        Player player = GetPlayerAsync(id).Result;
        player.Avatar = avatar;
        player.Title = title;
        _db.SaveChangesAsync();
    }

    public void AddCoins(int id, int amount)
    {
        Player player = GetPlayerAsync(id).Result;
        player.CoinsTotal += amount;
        _db.SaveChangesAsync();
    }

    public void RemoveCoins(int id, int amount)
    {
        Player player = GetPlayerAsync(id).Result;
        player.CoinsTotal -= amount;
        _db.SaveChangesAsync();
    }

    public void UpdatePassword(int id, string password)
    {
        Player player = GetPlayerAsync(id).Result;
        player.Password = password;
        _db.SaveChangesAsync();
    }

    public void AddTitleFirstWords(int id, string[] newWords)
    {
        Player player = GetPlayerAsync(id).Result;
        player.AddTitleFirstWords(newWords);
        _db.SaveChangesAsync();
    }

    public void AddTitleSecondWords(int id, string[] newWords)
    {
        Player player = GetPlayerAsync(id).Result;
        player.AddTitleSecondWords(newWords);
        _db.SaveChangesAsync();
    }

    public void UpdateStanding(int id, string newStanding)
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

    public void AddAvatar(int id, string avatar)
    {
        Player player = GetPlayerAsync(id).Result;
        player.AddAvatar(avatar);
        _db.SaveChangesAsync();
    }
}
