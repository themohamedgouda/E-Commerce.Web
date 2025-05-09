﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstractionLayer;
using Shared;
using Shared.DataTranseferObject.ProductoduleDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controller
{
  
    [Authorize]
    [ApiController]
    [Route("api/[controller]")] // BaseURL/API/Products.
    public class ProductsController(IServicesManager _servicesManager) : APIBaseController
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductDto>>> GetAllProducts([FromQuery]ProductQueryPrams queryPrams)

        {
            var Products = await _servicesManager.ProductService.GetAllProductsAsync(queryPrams);
            if (Products == null)
            {
                return NotFound();
            }
            return Ok(Products);

        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int Id)
        {
            var Product = await _servicesManager.ProductService.GetProductByIdAsync(Id);
            if (Product == null)
            {
                return NotFound();
            }
            return Ok(Product);

        }
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllTypes()
        {
            var Types = await _servicesManager.ProductService.GetAllTypesAsync();
            if (Types == null)
            {
                return NotFound();
            }
            return Ok(Types);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllBrands()
        {
            var Brands = await _servicesManager.ProductService.GetAllBrandsAsync();
            if (Brands == null)
            {
                return NotFound();
            }
            return Ok(Brands);
        }
    }
}
