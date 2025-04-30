using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServicesAbstractionLayer;
using ServicesImplementationLayer.Specifications;
using Shared.DataTranseferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementationLayer
{
    public class ProductService(IUnitOfWork _unitOfWork , IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
           var Repository =  _unitOfWork.GetRepository<ProductBrand, int>();
           var Brands = await Repository.GetAllAsync();
           var BrandDtos = _mapper.Map<IEnumerable<BrandDto>>(Brands);
           return BrandDtos;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var Speacification = new ProductWithBrandAndTypeSpecifications();
            var Repository =  _unitOfWork.GetRepository<Product, int>();
            var Products = await Repository.GetAllAsync(Speacification);
            var ProductDtos = _mapper.Map<IEnumerable<ProductDto>>(Products);
            return ProductDtos;

        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var Repository = _unitOfWork.GetRepository<ProductType, int>();
            var Types = await Repository.GetAllAsync();
            var TypeDtos = _mapper.Map<IEnumerable<TypeDto>>(Types);
            return TypeDtos;

        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var Speacification = new ProductWithBrandAndTypeSpecifications(id);
            var Repository =  _unitOfWork.GetRepository<Product, int>();
            var Product = await Repository.GetByIdAsync(Speacification);
            if (Product == null)
            {
                return await Task.FromResult<ProductDto?>(null);
            }
            var ProductDto = _mapper.Map<ProductDto>(Product);
            return  await Task.FromResult<ProductDto?>(ProductDto);
        }
    }
}
