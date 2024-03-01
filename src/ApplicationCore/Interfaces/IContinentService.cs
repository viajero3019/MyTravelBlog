using MyTravelBlog.ApplicationCore.Entities;

namespace MyTravelBlog.ApplicationCore.Interfaces;

public interface IContinentService
{
    public Task<IEnumerable<Continent>> GetAllAsync();
    public Task<Continent> GetByIdAsync(int id);
}