using MyTravelBlog.ApplicationCore.Entities;
using MyTravelBlog.ApplicationCore.Interfaces;

namespace MyTravelBlog.ApplicationCore.Services;

public class CountryService : ICountryService
{
    private readonly IAsyncRepository<Country> _repository;

    public CountryService(IAsyncRepository<Country> repository)
    {
        _repository = repository;
    }
    
    public Task<ICollection<Country>> GetCountriesAsync() => _repository.ListAllAsync();
    
    public Task<Country> GetCountriyByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task AddCountryAsync(Country country) => _repository.AddAsync(country);

    public Task DeleteAsync(Country country) => _repository.DeleteAsync(country);

    public Task UpdateCountryAsync(Country country) => _repository.UpdateAsync(country);

}