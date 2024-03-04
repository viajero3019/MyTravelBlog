using Microsoft.AspNetCore.Identity;
using MyTravelBlog.Infrastructure.Data;
using MyTravelBlog.Infrastructure.Identity;

namespace MyTravelBlog.Web.Extensions;

public static class PreDbExtensions
{
    public static async void AddContextPopulation(WebApplication app)
    {
        using (var serviceScope = app.Services.CreateScope())
        {
            var scopeProvider = serviceScope.ServiceProvider;
            try
            {
                app.Logger.LogInformation("AddContextPopulation");
                
                var travelContext = scopeProvider.GetRequiredService<TravelContext>();
                await TravelContextSeed.SeedAsync(travelContext, app.Logger);

                var userManager = scopeProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scopeProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var identityContext = scopeProvider.GetRequiredService<AppIdentityDbContext>();
                await AppIdentityDbContextSeed.SeedAsync(identityContext, userManager, roleManager, app.Logger);

            }
            catch (Exception)
            {
                app.Logger.LogError("Population Failed");
                throw;
            }
        }
    }
}