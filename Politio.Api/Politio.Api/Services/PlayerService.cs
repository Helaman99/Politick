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

    public async Task<Player?> GetPlayerAsync(string email) 
        => await _db.Players.SingleOrDefaultAsync(p => p.Email == email);

    public async Task<Player> GetPlayerAsync(int id) 
        => await _db.Players.SingleAsync(p => p.Id == id);

    public string GetPlayerData(int id) 
        =>  GetPlayerAsync(id).Result.GetData();

    public bool SignUp(string email, string password)
    {
        if (GetPlayerAsync(email) == null)
        {
            Player newPlayer = new Player(email, password);
            _db.AddAsync(newPlayer);
            _db.SaveChangesAsync();
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
        => GetPlayerAsync(id).Result.Activation == 0 ? true : false;

    public bool ActivatePlayer(int id, int code) 
        => GetPlayerAsync(id).Result.Activate(code);

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

}
