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

    public async Task<Player> GetPlayerAsync(string email)
    {
        List<Player> result = await _db.Players.Where(player => player.Email == email).ToListAsync();
        if (!result.IsNullOrEmpty())
            return result.First();
        return null;
    }

    public async Task<Player> GetPlayerAsync(int id)
    {
        List<Player> result = await _db.Players.Where(player => player.Id == id).ToListAsync();
        if (!result.IsNullOrEmpty())
            return result.First();
        return null;
    }

    public string GetPlayerData(int id)
    {
        Player player = GetPlayerAsync(id).Result;
        if (player is not null)
            return player.GetData();
        return "Null";
    }

    public int Login(string email, string password)
    {
        Player player = GetPlayerAsync(email).Result;
        if (player is not null && player.CheckPassword(password))
            return player.Id;
        return -1;
    }

    public void UpdateCard(int id, string avatar, string title)
    {
        Player player = GetPlayerAsync(id).Result;
        if (player is not null)
        {
            player.Avatar = avatar;
            player.Title = title;
            _db.Players.Add(player);
            _db.SaveChanges();
        }
    }

    public void AddCoins(int id, int amount)
    {
        Player player = GetPlayerAsync(id).Result;
        if (player is not null)
        {
            player.CoinsTotal += amount;
            _db.Players.Add(player);
            _db.SaveChanges();
        }
    }

    public void RemoveCoins(int id, int amount)
    {
        Player player = GetPlayerAsync(id).Result;
        if (player is not null)
        {
            player.CoinsTotal -= amount;
            _db.Players.Add(player);
            _db.SaveChanges();
        }
    }

    public void UpdatePassword(int id, string password)
    {
        Player player = GetPlayerAsync(id).Result;
        if (player is not null)
        {
            player.Password = password;
            _db.Players.Add(player);
            _db.SaveChanges();
        }
    }
}
