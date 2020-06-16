using System;
using System.Linq.Expressions;

namespace OrderManagement.DataAccess
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>> IsSatisfiedBy { get; }
    }
}