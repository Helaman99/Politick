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

    public async Task<Player> GetPlayer(int id)
    {
        List<Player> result = await _db.Players.Where(player => player.Id == id).ToListAsync();
        if (!result.IsNullOrEmpty())
            return result.First();
        return null;
    }

    public string GetPlayerData(int id)
    {
        Player player = GetPlayer(id).Result;
        if (player is not null)
            return player.GetData();
        return "Null";
    }

    public int Login(string email, string password)
    {
        Player player = GetPlayer(email).Result;
        if (player is not null && player.CheckPassword(password))
            return player.Id;
        return -1;
    }

    public void UpdateCard(int id, string avatar, string title)
    {
        Player player = GetPlayer(id).Result;
        if (player is not null)
        {
            player.Avatar = avatar;
            player.Title = title;
        }
    }

    public void AddCoins(int id, int amount)
    {
        Player player = GetPlayer(id).Result;
        if (player is not null)
        {
            player.CoinsTotal += amount;
        }
    }

    public void RemoveCoins(int id, int amount)
    {
        Player player = GetPlayer(id).Result;
        if (player is not null)
        {
            player.CoinsTotal -= amount;
        }
    }

    public void UpdatePassword(int id, string password)
    {
        Player player = GetPlayer(id).Result;
        if (player is not null)
            player.Password = password;
    }
}
