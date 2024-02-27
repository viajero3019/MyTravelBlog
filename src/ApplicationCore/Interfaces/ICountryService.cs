using MyTravelBlog.ApplicationCore.Entities;

namespace MyTravelBlog.ApplicationCore.Interfaces;

public interface ICountryService
{
    Task<ICollection<Country>> GetCountriesAsync();
    Task<Country> GetCountriyByIdAsync(int id);
    Task AddCountryAsync(Country country);
    Task UpdateCountryAsync(Country country);
}