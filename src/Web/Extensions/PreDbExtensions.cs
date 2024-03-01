using MyTravelBlog.Infrastructure.Data;

namespace MyTravelBlog.Web.Extensions;

public static class PreDbExtensions
{
    public static async void AddContextPopulation(WebApplication app)
    {
        app.Logger.LogInformation("AddContextPopulation");
        using (var serviceScope = app.Services.CreateScope())
        {
            var scopeProvider = serviceScope.ServiceProvider;
            try
            {
                var travelContext = scopeProvider.GetRequiredService<TravelContext>();
                await TravelContextSeed.SeedAsync(travelContext, app.Logger);

            }
            catch(Exception)
            {
                 app.Logger.LogError("Population Failed");
                throw;
            }
        }
    }
}