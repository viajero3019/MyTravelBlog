using System.Linq.Expressions;
using MyTravelBlog.ApplicationCore.Entities;

namespace MyTravelBlog.ApplicationCore.Specifications;

public sealed class CountryFilterSpecification : BaseSpecification<Country>
{
    public CountryFilterSpecification(int continentId) : base(i => i.ContinentId == continentId)
    {
    }
}