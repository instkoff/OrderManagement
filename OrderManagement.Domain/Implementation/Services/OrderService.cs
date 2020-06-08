using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Domain.Implementation.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public OrderService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<int> Create(OrderModel orderModel)
        {
            var orderEntity = _mapper.Map<OrderEntity>(orderModel);
            var providerCheck = await _dbRepository.Get<ProviderEntity>(p => p.Name == orderModel.Provider.Name)
                .FirstOrDefaultAsync();
            if (providerCheck != null)
            {
                orderEntity.Provider = providerCheck;
            }
            await _dbRepository.AddAsync(orderEntity);
            await _dbRepository.SaveChangesAsync();
            return orderEntity.Id;
        }

        public List<OrderModel> GetAll()
        {
            var orderCollection = _dbRepository.GetAll<OrderEntity>()
                .Include(oi => oi.OrderItems)
                .Include(p=>p.Provider)
                .ToList();
            var orderModels = _mapper.Map<List<OrderModel>>(orderCollection);
            return orderModels;
        }

        public async Task<OrderModel> Get(int id)
        {
            var orderEntity = await _dbRepository.Get<OrderEntity>(x => x.Id == id)
                .Include(oi => oi.OrderItems)
                .Include(p=>p.Provider)
                .FirstOrDefaultAsync();
            var orderModel = _mapper.Map<OrderModel>(orderEntity);
            return orderModel;
        }

        public async Task<int> Update(OrderModel orderModel)
        {
            var orderEntity = _mapper.Map<OrderEntity>(orderModel);
            await _dbRepository.UpdateAsync<OrderEntity>(orderEntity);
            await _dbRepository.SaveChangesAsync();
            return orderEntity.Id;
        }

        public async Task Delete(int id)
        {
            await _dbRepository.RemoveAsync<OrderEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }

    }
}