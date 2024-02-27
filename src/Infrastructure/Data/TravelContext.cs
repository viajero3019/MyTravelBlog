using Microsoft.EntityFrameworkCore;
using MyTravelBlog.ApplicationCore.Entities;

namespace MyTravelBlog.Infrastructure.Data;

public class TravelContext : DbContext
{
    public TravelContext(DbContextOptions<TravelContext> options) : base(options) { }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Continent> Continents { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Article> Articles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}