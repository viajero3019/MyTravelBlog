using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyTravelBlog.Infrastructure.Data;
using MyTravelBlog.Infrastructure.Identity;

namespace MyTravelBlog.Infrastructure;

public static class Dependencies
{
    public static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
    {
        bool useOnlyInMemoryDatabase = true;

        if(useOnlyInMemoryDatabase)
        {
            services.AddDbContext<AppIdentityDbContext>(context => context.UseInMemoryDatabase("Identity"));
            services.AddDbContext<TravelContext>(context => context.UseInMemoryDatabase("Travel"));
        }

    }
}