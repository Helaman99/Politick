using Microsoft.AspNetCore.Identity;

namespace Politick.Api.Data;

public class AppUser : IdentityUser
{
    public required string Name { get; set; }
    public int GameCount { get; set; }
    public double AverageAttempts { get; set; }
    public int AverageSecondsPerGame { get; set; }

}