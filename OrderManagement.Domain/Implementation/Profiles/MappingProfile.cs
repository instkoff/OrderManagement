using AutoMapper;
using OrderManagement.DataAccess.Entities;
using OrderManagement.Domain.Contracts.Models;

namespace OrderManagement.Domain.Implementation.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderModel, OrderEntity>();
            CreateMap<OrderItemModel, OrderItemEntity>();
            CreateMap<ProviderModel, ProviderEntity>();

            CreateMap<OrderItemEntity, OrderItemModel>();
            CreateMap<OrderEntity, OrderModel>();
            CreateMap<ProviderEntity, ProviderModel>();
        }
    }
}