using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using OrderManagement.DataAccess;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;
using OrderManagement.Domain.Contracts.Services;

namespace OrderManagement.Domain.Implementation.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public OrderItemService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public List<OrderItemModel> GetAllDistinct()
        {
            var orderItemEntities = _dbRepository.GetAll<OrderItemEntity>().Distinct();
            if (!orderItemEntities.Any())
                return null;
            var orderItemModels = _mapper.Map<List<OrderItemModel>>(orderItemEntities);
            return orderItemModels;
        }
    }
}
