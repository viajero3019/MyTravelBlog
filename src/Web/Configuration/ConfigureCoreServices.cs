using MyTravelBlog.ApplicationCore.Interfaces;
using MyTravelBlog.ApplicationCore.Services;
using MyTravelBlog.Infrastructure.Data;
using MyTravelBlog.Infrastructure.Logging;

namespace MyTravelBlog.Web.Configuration;

public static class ConfigureCoreServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));

        services.AddScoped<ICountryService, CountryService>();

        services.AddScoped(typeof(IAppLogger<>), typeof(AppLogger<>));

        return services;
    }
}