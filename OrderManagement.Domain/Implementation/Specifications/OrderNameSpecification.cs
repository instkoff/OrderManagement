using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Domain.Implementation.Specifications
{
    public class OrderNameSpecification : IOrderSpecification
    {
        private readonly FilterModel _filterModel;

        public OrderNameSpecification(FilterModel filterModel)
        {
            _filterModel = filterModel;
        }
        public bool IsSatisfiedBy(OrderModel order)
        {
            return order.Name.Equals(_filterModel.OrderName);
        }
    }
}
