using AutoMapper;
using DomainLayer.Models.Order;
using Shared.DataTranseferObject.IdentityModuleDto;
using Shared.DataTranseferObject.OrderModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementationLayer.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<AdderessDto, OrderAddress>().ReverseMap();
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(dest => dest.DelivaryMethod, opt => opt.MapFrom(src => src.DelivaryMethod.ShortName));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.PictureUrl, opt => opt.MapFrom<OrderItemPictureUrlResolver>());



        }
    }
}
