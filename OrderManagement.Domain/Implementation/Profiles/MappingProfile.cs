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
            CreateMap<OrderItemModel, OrderItemEntity>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ItemName));
            CreateMap<ProviderModel, ProviderEntity>();

            CreateMap<OrderItemEntity, OrderItemModel>()
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.Name));
            CreateMap<OrderEntity, OrderModel>();
            CreateMap<ProviderEntity, ProviderModel>();
        }
    }
}