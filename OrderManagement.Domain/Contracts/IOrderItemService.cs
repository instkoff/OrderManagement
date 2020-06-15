using System.Collections.Generic;
using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Domain.Contracts
{
    public interface IOrderItemService
    {
        List<OrderItemModel> GetAllDistinct();
    }
}