using System;
using System.Linq.Expressions;
using OrderManagement.DataAccess;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;
using OrderManagement.Domain.Contracts.Specifications;

namespace OrderManagement.Domain.Implementation.Specifications
{
    public class OrderNameSpecification : BaseSpecification<OrderEntity>
    {
        public OrderNameSpecification(string orderName)
        {
            Criteria = i => i.Name.Equals(orderName);
        }

    }
}
