using AutoMapper;
using AutoMapper.Execution;
using DomainLayer.Models.Order;
using Microsoft.Extensions.Configuration;
using Shared.DataTranseferObject.OrderModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementationLayer.MappingProfiles
{
    internal class OrderItemPictureUrlResolver(IConfiguration _configuration) : IValueResolver<OrderItem, OrderItemDto, string>
    {
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.Product.PictureUrl))
                return string.Empty;
            var url = $"{_configuration.GetSection("Urls")["BaseUrl"]}{source.Product.PictureUrl} ";
            return url;
        }

    }
}
