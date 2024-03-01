using MyTravelBlog.ApplicationCore.Entities;
using MyTravelBlog.ApplicationCore.Interfaces;

namespace MyTravelBlog.ApplicationCore.Services;

public class ContinentService : IContinentService, ICrudService<Continent>
{
    private readonly IAsyncRepository<Continent> _repository;

    public ContinentService(IAsyncRepository<Continent> repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Continent>> GetAllAsync() => _repository.ListAllAsync();

    public Task<Continent> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

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