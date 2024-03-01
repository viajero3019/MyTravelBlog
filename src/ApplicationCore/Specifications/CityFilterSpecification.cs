using System.Linq.Expressions;
using MyTravelBlog.ApplicationCore.Entities;

namespace MyTravelBlog.ApplicationCore.Specifications;

public sealed class CityFilterSpecification : BaseSpecification<City>
{
    public CityFilterSpecification(int countryId) : base(i => i.CountryId == countryId)
    {
    }
}