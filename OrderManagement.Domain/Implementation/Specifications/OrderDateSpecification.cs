using System;
using System.Linq.Expressions;
using OrderManagement.DataAccess;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Domain.Implementation.Specifications
{
    public class OrderDateSpecification : ISpecification<OrderEntity>
    {
        public Expression<Func<OrderEntity, bool>> IsSatisfiedBy { get; }
        public OrderDateSpecification(FilterModel filterModel)
        {
            IsSatisfiedBy = o => o.Date.Equals(filterModel.OrderDate);
        }
    }
}
