using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;
using OrderManagement.Domain.Contracts.Services;
using OrderManagement.Domain.Contracts.Specifications;

namespace OrderManagement.Domain.Implementation.Specifications
{
    public class OrderProviderIdSpecification : BaseSpecification<OrderEntity>
    {
        public OrderProviderIdSpecification(int providerId)
        {
            Criteria = o => o.ProviderId.Equals(providerId);
        }
    }
}
