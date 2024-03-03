using MyTravelBlog.ApplicationCore.Entities;
using MyTravelBlog.ApplicationCore.Interfaces;
using MyTravelBlog.ApplicationCore.Specifications;

namespace MyTravelBlog.ApplicationCore.Services;

public class CityService : ICityService, ICrudService<City>
{
    private readonly IAsyncRepository<City> _repository;
    private readonly IAppLogger<CityService> _logger;

    public CityService(IAsyncRepository<City> repository, IAppLogger<CityService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IEnumerable<City>> GetAllAsync()
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
    public async Task<IEnumerable<City>> GetFitlerAsync(int countryId)
    {
        var spec = new CityFilterSpecification(countryId);
        var res = await _repository.ListWithFilterAsync(spec);
        return res;
    }

    public Task<City> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task AddAsync(City city) => _repository.AddAsync(city);

    public Task DeleteAsync(City city) => _repository.DeleteAsync(city);

    public Task UpdateAsync(City city) => _repository.UpdateAsync(city);
}