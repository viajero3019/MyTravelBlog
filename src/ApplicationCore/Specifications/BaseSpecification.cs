using System.Linq.Expressions;
using MyTravelBlog.ApplicationCore.Interfaces;

namespace MyTravelBlog.ApplicationCore.Specifications;

public class BaseSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, bool>>? Criteria { get; }
    public List<Expression<Func<T, object>>>? Includes { get; }
    public Expression<Func<T, object>>? OrderBy { get; private set;}
    
    public BaseSpecification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes!.Add(includeExpression);
    }

    protected virtual void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

}