using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Politick.Api.Data;
using System.Numerics;
using System.Reflection.Metadata;

namespace Politick.Api.Data;

public class AppDbContext : IdentityDbContext<Player>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<Player> Players => Set<Player>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Player>()
            .Property(p => p.UnlockedTitleFirstWords)
            .HasMaxLength(4000);
        modelBuilder.Entity<Player>()
            .Property(p => p.UnlockedTitleSecondWords)
            .HasMaxLength(4000);
        modelBuilder.Entity<Player>()
            .Property(p => p.UnlockedAvatars)
            .HasMaxLength(4000);
    }
}
