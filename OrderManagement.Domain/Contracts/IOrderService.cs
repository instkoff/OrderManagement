using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Domain.Contracts
{
    public interface IOrderService
    {
        Task<int> Create(OrderModel orderModel);
        List<OrderModel> GetAll();
        List<ProviderModel> GetAllProviders();
        Task<OrderModel> Get(int id);
        Task<int> Update(OrderModel orderModel);
        Task Delete(int id);
    }
}