using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using MyTravelBlog.Infrastructure.Identity;

namespace MyTravelBlog.Web.Configuration;

public static class ConfigureAuthSettings
{
    public static IServiceCollection AddAuthSettings(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddDefaultUI()
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultTokenProviders();

        
        return services;
    }
}