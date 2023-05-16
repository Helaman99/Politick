using Microsoft.EntityFrameworkCore;
namespace Politio.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Player> Players { get; set; }
}
