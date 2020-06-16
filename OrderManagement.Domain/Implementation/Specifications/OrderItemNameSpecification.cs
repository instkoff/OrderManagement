﻿using System.Linq;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Domain.Implementation.Specifications
{
    public class OrderItemNameSpecification : IOrderSpecification
    {
        private readonly FilterModel _filterModel;

        public OrderItemNameSpecification(FilterModel filterModel)
        {
            _filterModel = filterModel;
        }
        public bool IsSatisfiedBy(OrderEntity order)
        {
            return order.OrderItems.Any(orderItem => orderItem.Name.Equals(_filterModel.OrderItemName));
        }
    }
}
