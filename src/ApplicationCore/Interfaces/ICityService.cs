using MyTravelBlog.ApplicationCore.Entities;

namespace MyTravelBlog.ApplicationCore.Interfaces;

public interface ICityService
{
    Task<IEnumerable<City>> GetFitlerAsync(int countryId);
}