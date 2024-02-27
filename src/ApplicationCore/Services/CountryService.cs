using MyTravelBlog.ApplicationCore.Entities;
using MyTravelBlog.ApplicationCore.Interfaces;

namespace MyTravelBlog.ApplicationCore.Services;

public class CountryService : ICountryService
{
    private readonly IAsyncRepository<Country> _repository;
    private readonly IAppLogger<CountryService> _logger;

    public CountryService(IAsyncRepository<Country> repository, IAppLogger<CountryService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<Country>> GetCountriesAsync()
    {
        var res = await _repository.ListAllAsync();
        _logger.LogInformation(res.Count().ToString());
        if (res.Any())
        {
            foreach (var item in res)
            {
                _logger.LogInformation(item.Name!);
            }
        }
        return res;
    }

    public Task<Country> GetCountriyByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task AddCountryAsync(Country country) => _repository.AddAsync(country);

    public Task DeleteAsync(Country country) => _repository.DeleteAsync(country);

    public Task UpdateCountryAsync(Country country) => _repository.UpdateAsync(country);

}