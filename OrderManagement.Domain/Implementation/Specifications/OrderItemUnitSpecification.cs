using System;
using System.Linq;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Domain.Implementation.Specifications
{
    public class OrderItemUnitSpecification : IOrderSpecification
    {
        private readonly FilterModel _filterModel;

        public OrderItemUnitSpecification(FilterModel filterModel)
        {
            _filterModel = filterModel;
        }
        public bool IsSatisfiedBy(OrderEntity order)
        {
            return order.OrderItems.Any(orderItem => orderItem.Unit.Equals(_filterModel.OrderItemUnit));
        }
    }
}
