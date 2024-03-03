using System.Linq.Expressions;

namespace MyTravelBlog.ApplicationCore.Interfaces;

public interface ISpecification<T>
{
    Expression<Func<T, bool>>? Criteria { get; }
    List<Expression<Func<T, object>>>? Includes { get; }
    string? IncludeStrings { get; }
    Expression<Func<T, object>>? OrderBy { get; }
}