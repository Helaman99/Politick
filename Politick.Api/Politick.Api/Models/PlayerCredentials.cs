namespace Politick.Api.Models;

public class PlayerCredentials
{
    public string Email { get; set; }
    public string Password { get; set; }
    public PlayerCredentials(string email, string password)
    {
        Email = email;
        Password = password;
    }
}