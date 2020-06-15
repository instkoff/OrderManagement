using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Domain.Contracts
{
    public interface IOrderSpecification
    {
        bool IsSatisfiedBy(OrderModel order);
    }
}
