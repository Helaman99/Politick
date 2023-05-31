using Microsoft.AspNetCore.Identity;
using Politick.Api.Data;
using System.Data;

namespace Politick.Api.Identity;
public static class IdentitySeed
{
    public static async Task SeedAsync(UserManager<Player> userManager, RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles
        await SeedRolesAsync(roleManager);

        // Seed Admin User
        await SeedAdminUserAsync(userManager);
    }

    private static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        // Seed Roles
        if (!await roleManager.RoleExistsAsync(Roles.Admin))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
        }
        if (!await roleManager.RoleExistsAsync(Roles.Special))
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Special));
        }
    }

    private static async Task SeedAdminUserAsync(UserManager<Player> userManager)
    {
        // Seed Admin User
        if (await userManager.FindByEmailAsync("Admin@intellitect.com") == null)
        {
            Player user = new("Admin@politick.com");

            IdentityResult result = userManager.CreateAsync(user, "SECRET").Result;

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, Roles.Admin);
                await userManager.AddToRoleAsync(user, Roles.Special);
            }
        }
    }
}