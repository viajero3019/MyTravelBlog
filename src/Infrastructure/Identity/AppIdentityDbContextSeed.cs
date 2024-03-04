using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MyTravelBlog.Infrastructure.Identity;

public class AppIdentityDbContextSeed : IdentityDbContext<ApplicationUser>
{
    public const string ADMINISTRATORS = "Administrators";
    public const string DEFAULT_PASSWORD = "Pass@word1";

    public static async Task SeedAsync(AppIdentityDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ILogger logger)
    {
        logger.LogInformation("Seeding DB Identity");
        
        if(!context.Users.Any())
        {
            await roleManager.CreateAsync(new IdentityRole(ADMINISTRATORS));

            var adminUser = new ApplicationUser { UserName = "admin@mytravelblog.com", Email = "admin@mytravelblog.com" };
            await userManager.CreateAsync(adminUser, DEFAULT_PASSWORD);

            await userManager.AddToRoleAsync(adminUser, ADMINISTRATORS);

        }

    }
}