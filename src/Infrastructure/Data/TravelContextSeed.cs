using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyTravelBlog.ApplicationCore.Entities;

namespace MyTravelBlog.Infrastructure.Data;

public class TravelContextSeed
{
    public static async Task SeedAsync(TravelContext context, ILogger logger, int retry = 0)
    {
        var retryForAvailability = retry;
        try
        {
            if(!await context.Countries.AnyAsync())
            {
                logger.LogInformation("Seeding DB");
                await context.Countries.AddRangeAsync(GetPreconfiguredCountries());
                await context.SaveChangesAsync();
            }
        }
        catch(Exception ex)
        {
            if(retryForAvailability >= 10) throw;

            retryForAvailability++;

            logger.LogError(ex.Message);
            await SeedAsync(context, logger, retryForAvailability);
            throw;
        }
    }

    static IEnumerable<Country> GetPreconfiguredCountries() 
    {
        return new List<Country>{ 
            new Country { Id = 1, Name = "Colombia", Description = "The best country in the world", ContinentId = 1 }, 
            new Country { Id = 2, Name = "Venezuela", Description = "Nice country", ContinentId = 1 }, 
            new Country { Id = 3, Name = "Ecuador", Description = "Nice country", ContinentId = 1 }, 
            new Country { Id = 4, Name = "Spain", Description = "Nice country", ContinentId = 2  }, 
            new Country { Id = 5, Name = "Portugal", Description = "Nice country", ContinentId = 2 }, 
        };

    } 
}