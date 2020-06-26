using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OrderManagement.DataAccess;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts;
using OrderManagement.Domain.Contracts.Models;
using OrderManagement.Domain.Contracts.Services;
using OrderManagement.Domain.Contracts.Specifications;
using OrderManagement.Domain.Implementation.Specifications;

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
            var providerCheck = await _dbRepository.Get<ProviderEntity>(p => p.Id == orderModel.Provider.Id)
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
                .Include(p=>p.Provider)
                .ToList();
            var orderModels = _mapper.Map<List<OrderModel>>(orderCollection);
            return orderModels;
        }

        public List<OrderModel> GetFilteredOrders(FilterModel filter)
        {
            var queryCollection = _dbRepository.GetAll<OrderEntity>();
            if (!string.IsNullOrEmpty(filter.OrderName))
            {
                queryCollection = queryCollection.Specify(new OrderNameSpecification(filter.OrderName));
            }
            if (filter.OrderDate != null)
            {
                queryCollection = queryCollection.Specify(new OrderDateSpecification(filter.OrderDate));
            }
            if (!string.IsNullOrEmpty(filter.OrderItemName))
            {
                queryCollection = queryCollection.Specify(new OrderItemNameSpecification(filter.OrderItemName));
            }
            if (!string.IsNullOrEmpty(filter.OrderProviderName))
            {
                queryCollection = queryCollection.Specify(new OrderProviderSpecification(filter.OrderProviderName));
            }
            if (!string.IsNullOrEmpty(filter.OrderItemUnit))
            {
                queryCollection = queryCollection.Specify(new OrderItemUnitSpecification(filter.OrderItemUnit));
            }
            if (filter.OrderProviderId != 0)
            {
                queryCollection = queryCollection.Specify(new OrderProviderIdSpecification(filter.OrderProviderId));
            }

            var filteredOrders = queryCollection.Include(p=>p.Provider).ToList();
            var orderModels = _mapper.Map<List<OrderModel>>(filteredOrders);
            return orderModels;
        }

        //ToDo Сделать выборку значений для фильтра

        public List<ProviderModel> GetAllProviders()
        {
            var providerCollection = _dbRepository.GetAll<ProviderEntity>();
            var providerModels = _mapper.Map<List<ProviderModel>>(providerCollection);
            return providerModels;
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
            await _dbRepository.UpdateAsync(orderEntity);
            await _dbRepository.SaveChangesAsync();
            return orderEntity.Id;
        }

        public async Task Delete(int id)
        {
            await _dbRepository.RemoveAsync<OrderEntity>(id);
            await _dbRepository.SaveChangesAsync();
        }

        public List<OrderItemModel> GetOrderItems(int orderId)
        {
            var orderItemEntities = _dbRepository.GetAll<OrderItemEntity>()
                .Where(items => items.OrderEntityId == orderId);
            var orderItemModels = _mapper.Map<List<OrderItemModel>>(orderItemEntities);
            return orderItemModels;
        }
    }
}