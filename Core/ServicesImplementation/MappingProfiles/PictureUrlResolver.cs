﻿using AutoMapper;
using AutoMapper.Execution;
using DomainLayer.Models.Product;
using Microsoft.Extensions.Configuration;
using Shared.DataTranseferObject.ProductoduleDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementationLayer.MappingProfiles
{
    class PictureUrlResolver(IConfiguration _configuration) : IValueResolver<Product, ProductDto, string>
    {
        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (string.IsNullOrEmpty(source.PictureUrl))
            {
                return string.Empty;
            }
            string baseUrl = $"{_configuration.GetSection("Urls")["BaseUrl"]}";

            return $"{baseUrl}{source.PictureUrl}";
        }
    }
}
