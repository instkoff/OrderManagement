using System.Linq;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;
using OrderManagement.Domain.Contracts.Services;
using OrderManagement.Domain.Contracts.Specifications;

namespace OrderManagement.Domain.Implementation.Specifications
{
    public class OrderItemNameSpecification : BaseSpecification<OrderEntity>
    {
        public OrderItemNameSpecification(string itemName)
        {
            Criteria = o => o.OrderItems.Any(i => i.Name.Equals(itemName));
        }
    }
}
