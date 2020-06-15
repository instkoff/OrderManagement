using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Domain.Implementation.Specifications
{
    public class OrderDateSpecification : IOrderSpecification
    {
        private readonly FilterModel _filterModel;

        public OrderDateSpecification(FilterModel filterModel)
        {
            _filterModel = filterModel;
        }
        public bool IsSatisfiedBy(OrderModel order)
        {
            return order.Date.Equals(_filterModel.OrderDate);
        }
    }
}
