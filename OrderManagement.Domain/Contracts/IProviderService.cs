using System.Collections.Generic;
using System.Threading.Tasks;
using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Domain.Contracts
{
    public interface IProviderService
    {
        Task<int> Create(ProviderModel providerModel);
        List<ProviderModel> GetAll();
        Task<ProviderModel> Get(int id);
    }
}