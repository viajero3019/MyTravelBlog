using MyTravelBlog.ApplicationCore.Entities;

namespace MyTravelBlog.ApplicationCore.Interfaces;

public interface ICountryService
{
    Task<IEnumerable<Country>> GetFitlerAsync(int continentId);
}