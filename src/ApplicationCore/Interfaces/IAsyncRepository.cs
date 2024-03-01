using MyTravelBlog.ApplicationCore.Entities;

namespace MyTravelBlog.ApplicationCore.Interfaces;

public interface IAsyncRepository<T> where T : BaseEntity, IAggregateRoot
{
    Task<IEnumerable<T>> ListAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}