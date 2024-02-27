using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTravelBlog.Infrastructure.Data;

namespace MyTravelBlog.Infrastructure;

public static class Dependencies
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        bool useOnlyInMemoryDatabase = true;

        if(useOnlyInMemoryDatabase)
        {
            services.AddDbContext<TravelContext>(context => context.UseInMemoryDatabase("Travel"));
        }

    }
}