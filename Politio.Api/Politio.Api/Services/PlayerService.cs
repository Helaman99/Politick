using Microsoft.EntityFrameworkCore;
using Politio.Api.Data;
using Microsoft.IdentityModel.Tokens;

namespace Politio.Api.Services;

public class PlayerService
{
    private readonly AppDbContext _db;
    public PlayerService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Player> GetPlayer(string email)
    {
        List<Player> result = await _db.Players.Where(player => player.Email == email).ToListAsync();
        if (!result.IsNullOrEmpty())
            return result.First();
        return null;
    }

    public string GetPlayerData(string email)
    {
        Player player = GetPlayer(email).Result;
        if (player is not null)
            return player.GetData();
        return "Null";
    }

    public bool Login(string email, string password)
    {
        Player player = GetPlayer(email).Result;
        if (player is not null)
            return player.CheckPassword(password);
        return false;
    }

    public void UpdateCard(string email, string avatar, string title)
    {
        Player player = GetPlayer(email).Result;
        if (player is not null)
        {
            player.Avatar = avatar;
            player.Title = title;
        }
    }

    public void AddCoins(string email, int amount)
    {
        Player player = GetPlayer(email).Result;
        if (player is not null)
        {
            player.CoinsTotal += amount;
        }
    }

    public void RemoveCoins(string email, int amount)
    {
        Player player = GetPlayer(email).Result;
        if (player is not null)
        {
            player.CoinsTotal -= amount;
        }
    }

    public void UpdatePassword(string email, string password)
    {
        Player player = GetPlayer(email).Result;
        if (player is not null)
            player.Password = password;
    }
}
