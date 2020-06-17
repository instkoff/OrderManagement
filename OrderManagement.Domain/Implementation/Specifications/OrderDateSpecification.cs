using System;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts.Specifications;

namespace OrderManagement.Domain.Implementation.Specifications
{
    public class OrderDateSpecification : BaseSpecification<OrderEntity>
    {
        public OrderDateSpecification(DateTime? orderDate)
        {
            Criteria = i => i.Date.Equals(orderDate);
        }
    }
}
