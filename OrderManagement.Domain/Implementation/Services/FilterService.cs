using System.Collections.Generic;
using System.Linq;
using OrderManagement.DataAccess;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts;

namespace OrderManagement.Domain.Implementation.Services
{
    public class FilterService
    {
        private readonly IDbRepository _dbRepository;

        public FilterService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public List<OrderEntity> GetFilteredOrders(IOrderSpecification specification, IEnumerable<OrderEntity> ordersCollection)
        {
            return ordersCollection.Where(specification.IsSatisfiedBy).ToList();
        }
    }
}
