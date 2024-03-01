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
            if (!await context.Continents.AnyAsync())
            {
                logger.LogInformation("Seeding DB Continents");
                await context.Continents.AddRangeAsync(GetPreconfiguredContinents());
                await context.SaveChangesAsync();
            }

            if (!await context.Countries.AnyAsync())
            {
                logger.LogInformation("Seeding DB Countries");
                await context.Countries.AddRangeAsync(GetPreconfiguredCountries());
                await context.SaveChangesAsync();
            }

            if (!await context.Cities.AnyAsync())
            {
                logger.LogInformation("Seeding DB Cities");
                await context.Cities.AddRangeAsync(GetPreconfiguredCities());
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            if (retryForAvailability >= 10) throw;

            retryForAvailability++;

            logger.LogError(ex.Message);
            await SeedAsync(context, logger, retryForAvailability);
            throw;
        }
    }

    static IEnumerable<Continent> GetPreconfiguredContinents()
    {
        return new List<Continent>{
            new Continent { Id = 1, Name = "South America", Description = "The best Continent in the world"},
            new Continent { Id = 2, Name = "Europe", Description = "Nice Continent" },
            new Continent { Id = 3, Name = "Asia", Description = "Nice Continent"},
            new Continent { Id = 4, Name = "North America", Description = "Nice Continent" },
            new Continent { Id = 5, Name = "Africa", Description = "Nice Continent"},
        };
    }

    static IEnumerable<Country> GetPreconfiguredCountries()
    {
        return new List<Country>{
            new Country { Id = 1, Name = "Colombia", Description = "The best country in the world", ContinentId = 1 },
            new Country { Id = 2, Name = "Venezuela", Description = "Nice country", ContinentId = 1 },
            new Country { Id = 3, Name = "Egypt", Description = "Nice country", ContinentId = 5 },
            new Country { Id = 4, Name = "Canada", Description = "Nice country", ContinentId = 4 },
            new Country { Id = 5, Name = "Spain", Description = "Nice country", ContinentId = 2  },
            new Country { Id = 6, Name = "Portugal", Description = "Nice country", ContinentId = 2 },
            new Country { Id = 7, Name = "China", Description = "Nice country", ContinentId = 3 },
        };
    }

    static IEnumerable<City> GetPreconfiguredCities()
    {
        return new List<City>{
            new City { Id = 1, Name = "Medellín", Description = "The best City in the world",  CountryId = 1 },
            new City { Id = 2, Name = "Shangai", Description = "Nice City", CountryId = 7 },
            new City { Id = 3, Name = "Madrid", Description = "Nice City", CountryId = 5 },
            new City { Id = 4, Name = "Lisboa", Description = "Nice City", CountryId = 6  },
            new City { Id = 5, Name = "Quebec", Description = "Nice City", CountryId = 4 },
            new City { Id = 6, Name = "El Cairo", Description = "Nice City", CountryId = 3 },
        };
    }


}