using MyTravelBlog.Infrastructure;
using MyTravelBlog.Web.Configuration;
using MyTravelBlog.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    Dependencies.ConfigureServices(builder.Configuration, builder.Services);
}

builder.Services.AddAuthSettings();
builder.Services.AddCookieSettings();

builder.Services.AddCoreServices();

builder.Services.AddAuthentication();

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Continent");
    options.Conventions.AuthorizeFolder("/Country");
    options.Conventions.AuthorizeFolder("/City");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

PreDbExtensions.AddContextPopulation(app);

app.Run();
