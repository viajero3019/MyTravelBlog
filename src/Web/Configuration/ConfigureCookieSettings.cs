namespace MyTravelBlog.Web.Configuration;

public static class ConfigureCookieSettings
{
    public const int ValidityMinutesPeriod = 60;
    public const string IdentifierCookieName = "MyAppIdentifier";

    public static IServiceCollection AddCookieSettings(this IServiceCollection services)
    {
        services.Configure<CookiePolicyOptions>(options => options.MinimumSameSitePolicy = SameSiteMode.Strict);

        services.ConfigureApplicationCookie(options => 
        {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(ValidityMinutesPeriod);
            options.LoginPath = "/Account/Login";
            options.LogoutPath = "/Account/Logout";
            options.Cookie = new CookieBuilder {
                Name = IdentifierCookieName,
                IsEssential = true
            };
        });
        
        return services;
    }
}