using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Domain.Implementation.Specifications
{
    public class OrderProviderSpecification : IOrderSpecification
    {
        private readonly FilterModel _filterModel;

        public OrderProviderSpecification(FilterModel filterModel)
        {
            _filterModel = filterModel;
        }
        public bool IsSatisfiedBy(OrderEntity order)
        {
            return order.Provider.Name.Equals(_filterModel.OrderProviderName);
        }
    }
}
