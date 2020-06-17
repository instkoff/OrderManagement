using System;
using System.Linq;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;
using OrderManagement.Domain.Contracts.Services;
using OrderManagement.Domain.Contracts.Specifications;

namespace OrderManagement.Domain.Implementation.Specifications
{
    public class OrderItemUnitSpecification : BaseSpecification<OrderEntity>
    {
        public OrderItemUnitSpecification(string unitName)
        {
            Criteria = o=>o.OrderItems.Any(orderItem => orderItem.Unit.Equals(unitName));
        }
    }
}
