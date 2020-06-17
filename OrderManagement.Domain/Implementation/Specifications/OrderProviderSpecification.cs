using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts.Specifications;

namespace OrderManagement.Domain.Implementation.Specifications
{
    public class OrderProviderSpecification : BaseSpecification<OrderEntity>
    {
        public OrderProviderSpecification(string providerName)
        {
            Criteria = o=>o.Provider.Name.Equals(providerName);
        }
    }
}
