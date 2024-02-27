namespace MyTravelBlog.ApplicationCore.Interfaces;

public interface IDeleteService
{
    Task DeleteAsync(int id);
}