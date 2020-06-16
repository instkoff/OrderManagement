using System;
using System.Linq.Expressions;
using OrderManagement.DataAccess;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Domain.Implementation.Specifications
{
    public class OrderNameSpecification : ISpecification<OrderEntity>
    {
        public OrderNameSpecification(FilterModel filterModel)
        {
            IsSatisfiedBy = o => o.Name.Equals(filterModel.OrderItemName);

        }

        public Expression<Func<OrderEntity, bool>> IsSatisfiedBy { get; }
    }
}
