using System.Linq.Expressions;
using MyTravelBlog.ApplicationCore.Entities;

namespace MyTravelBlog.ApplicationCore.Specifications;

public sealed class ContinentIncludeSpecification : BaseSpecification<Continent>
{
    public ContinentIncludeSpecification() : base()
    {
        AddInclude(nameof(Continent.Countries));
    }
}