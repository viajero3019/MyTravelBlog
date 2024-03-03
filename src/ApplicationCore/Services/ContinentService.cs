using MyTravelBlog.ApplicationCore.Entities;
using MyTravelBlog.ApplicationCore.Interfaces;
using MyTravelBlog.ApplicationCore.Specifications;

namespace MyTravelBlog.ApplicationCore.Services;

public class ContinentService : IContinentService, ICrudService<Continent>
{
    private readonly IAsyncRepository<Continent> _repository;

    public ContinentService(IAsyncRepository<Continent> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Continent>> GetAllAsync() => await _repository.ListAllAsync();

    public Task<Continent> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

    public async Task<IEnumerable<Continent>> GetWithIncludeAsync()
    {
        var spec = new ContinentIncludeSpecification();
        return await _repository.ListWithIncludeAsync(spec);
    }

    public Task<IEnumerable<Continent>> GetFitlerAsync(params object[] filters)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Continent country)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Continent country)
    {
        throw new NotImplementedException();
    }


    public Task UpdateAsync(Continent country)
    {
        throw new NotImplementedException();
    }
}