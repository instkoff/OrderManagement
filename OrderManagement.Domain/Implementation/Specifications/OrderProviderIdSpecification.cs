using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Domain.Implementation.Specifications
{
    public class OrderProviderIdSpecification : IOrderSpecification
    {
        private readonly FilterModel _filterModel;

        public OrderProviderIdSpecification(FilterModel filterModel)
        {
            _filterModel = filterModel;
        }
        public bool IsSatisfiedBy(OrderModel order)
        {
            return order.Provider.Id.Equals(_filterModel.OrderProviderId);
        }
    }
}
