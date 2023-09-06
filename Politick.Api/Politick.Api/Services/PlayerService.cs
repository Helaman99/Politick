using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Politick.Api.Data;
using Microsoft.IdentityModel.Tokens;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Politick.Api.Services;

public class PlayerService
{
    private readonly AppDbContext _db;
    public PlayerService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Player> GetPlayerAsync(string email) 
        => await _db.Players.SingleAsync(p => p.Email == email);

    public async Task<Player> GetPlayerDataAsync(string email) 
        =>  await GetPlayerAsync(email);

    public string[] GetAvatarImages()
        => Directory.GetFiles("../Assets/Avatars");

    public async Task UpdateCardAsync(string email, PlayerCard playerCard)
    {
        Player player = await GetPlayerAsync(email);
        player.Avatar = playerCard.Avatar;
        player.Title = playerCard.Title;
        await _db.SaveChangesAsync();
    }

    public async Task AddCoinsAsync(string email, int amount)
    {
        Player player = await GetPlayerAsync(email);
        player.CoinsTotal += amount;
        await _db.SaveChangesAsync();
    }

    public async Task RemoveCoinsAsync(string email, int amount)
    {
        Player player = await GetPlayerAsync(email);
        player.CoinsTotal -= amount;
        await _db.SaveChangesAsync();
    }

    public async Task AddGameAsync(string email)
    {
        Player player = await GetPlayerAsync(email);
        player.GamesTotal++;
        await _db.SaveChangesAsync();
    }

    public async Task AddTitleFirstWordsAsync(string email, string[] newWords)
    {
        Player player = await GetPlayerAsync(email);
        player.AddTitleFirstWords(newWords);
        await _db.SaveChangesAsync();
    }

    public async Task AddTitleSecondWordsAsync(string email, string[] newWords)
    {
        Player player = await GetPlayerAsync(email);
        player.AddTitleSecondWords(newWords);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateStandingsAsync(string email, string[] newStandings)
    {
        Player player = await GetPlayerAsync(email);
        if (!newStandings.IsNullOrEmpty())
        {
            foreach (string standing in newStandings)
            {
                switch (standing.ToLower())
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
            }
        }
        await _db.SaveChangesAsync();
    }

    public async Task AddAvatarAsync(string email, string avatar)
    {
        Player player = await GetPlayerAsync(email);
        player.AddAvatar(avatar);
        await _db.SaveChangesAsync();
    }

    public async Task ChangeThemeAsync(string email, string newTheme)
    {
        Player player = await GetPlayerAsync(email);
        player.Theme = newTheme;
        await _db.SaveChangesAsync();
    }

    public async Task AddStrikeAsync(string email)
    {
        Player player = await GetPlayerAsync(email);
        player.Strikes++;

        if (player.Strikes > 2)
        {
            player.Suspended = true;
            player.TimesSuspended++;
            switch (player.TimesSuspended)
            {
                case 1: player.UnsuspendDay = DateTime.Now.Day + 1 % 31; break;
                case 2: player.UnsuspendDay = DateTime.Now.Day + 7 % 31; break;
                case 3: player.UnsuspendDay = 32; break;
            }
            player.Strikes = 0;
        }

        await _db.SaveChangesAsync();
    }
}
