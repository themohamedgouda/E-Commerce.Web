using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PrecedencesLayer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PrecedencesLayer
{
    public class DataSeeding(StoredDbContext _dbContext) : IDataSeeding
    {
        public void DataSeed()
        {
            try
            {
                if (_dbContext.Database.GetPendingMigrations().Any())
                {
                    _dbContext.Database.Migrate();
                }
                if (!_dbContext.ProductBrands.Any())
                {
                    var ProductBrandData = File.ReadAllText(@"..\Infrastructures\PrecedencesLayer\Data\DataSeed\brands.json");
                    //Convert Data To C# Object | Serialization
                    var ProductBrands = JsonSerializer.Deserialize<List<ProductBrand>>(ProductBrandData);

                    if (ProductBrands is not null && ProductBrands.Any())
                        _dbContext.ProductBrands.AddRange(ProductBrands);
                }
                if (!_dbContext.ProductTypes.Any())
                {
                    var ProductTypeData = File.ReadAllText(@"..\Infrastructures\PrecedencesLayer\Data\DataSeed\types.json");
                    //Convert Data To C# Object | Serialization
                    var ProductTypes = JsonSerializer.Deserialize<List<ProductType>>(ProductTypeData);

                    if (ProductTypes is not null && ProductTypes.Any())
                        _dbContext.ProductTypes.AddRange(ProductTypes);
                }
                if (!_dbContext.products.Any())
                {
                    var ProductData = File.ReadAllText(@"..\Infrastructures\PrecedencesLayer\Data\DataSeed\products.json");
                    //Convert Data To C# Object | Serialization
                    var Products = JsonSerializer.Deserialize<List<Product>>(ProductData);

                    if (Products is not null && Products.Any())
                        _dbContext.products.AddRange(Products);
                }
                _dbContext.SaveChanges();
            }
            catch(Exception ex) 
            {

            }
        }
    }
}
