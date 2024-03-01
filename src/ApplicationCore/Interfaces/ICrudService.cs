using MyTravelBlog.ApplicationCore.Entities;

namespace MyTravelBlog.ApplicationCore.Interfaces;

public interface ICrudService<T>
{
    Task AddAsync(T country);
    Task UpdateAsync(T country);
    Task DeleteAsync(T country);
}