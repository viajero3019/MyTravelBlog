using MyTravelBlog.ApplicationCore.Entities;
using MyTravelBlog.ApplicationCore.Interfaces;
using MyTravelBlog.ApplicationCore.Specifications;

namespace MyTravelBlog.ApplicationCore.Services;

public class CountryService : ICountryService, ICrudService<Country>
{
    private readonly IAsyncRepository<Country> _repository;
    private readonly IAppLogger<CountryService> _logger;

    public CountryService(IAsyncRepository<Country> repository, IAppLogger<CountryService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<Country>> GetAllAsync()
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
    public async Task<IEnumerable<Country>> GetFitlerAsync(int continentId)
    {
        var spec = new CountryFilterSpecification(continentId);
        var res = await _repository.ListWithFilterAsync(spec);
        return res;
    }

    public Task<Country> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task AddAsync(Country country) => _repository.AddAsync(country);

    public Task DeleteAsync(Country country) => _repository.DeleteAsync(country);

    public Task UpdateAsync(Country country) => _repository.UpdateAsync(country);
}