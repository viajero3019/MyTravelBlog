using Microsoft.EntityFrameworkCore;
using MyTravelBlog.ApplicationCore.Entities;
using MyTravelBlog.ApplicationCore.Interfaces;

namespace MyTravelBlog.Infrastructure.Data;

public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
{
    private readonly TravelContext _context;

    public EfRepository(TravelContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> ListAllAsync() => await _context.Set<T>().ToListAsync();

    public async Task<T> GetByIdAsync(int id) => (await _context.Set<T>().FindAsync(id))!;

    public async Task<IReadOnlyList<T>> ListWithFilterAsync(ISpecification<T> spec) => await _context.Set<T>().Where(spec.Criteria!).ToListAsync();
    public async Task<IReadOnlyList<T>> ListWithIncludeAsync(ISpecification<T> spec) => await _context.Set<T>().Include(spec.IncludeStrings!).ToListAsync();

    public async Task<T> AddAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

}