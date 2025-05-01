using DomainLayer.Contracts;
using DomainLayer.Models.Product;
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
        public async Task DataSeedAsync()
        {
            try
            {
                var PendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();
                if (PendingMigrations.Any())
                {
                    await _dbContext.Database.MigrateAsync();
                }
                if (!_dbContext.ProductBrands.Any())
                {
                    //var ProductBrandData = await File.ReadAllTextAsync(@"..\Infrastructures\PrecedencesLayer\Data\DataSeed\brands.json");
                    var ProductBrandData =  File.OpenRead(@"..\Infrastructures\PrecedencesLayer\Data\DataSeed\brands.json");
                    //Convert Data To C# Object | Serialization
                    var ProductBrands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(ProductBrandData);

                    if (ProductBrands is not null && ProductBrands.Any())
                       await  _dbContext.ProductBrands.AddRangeAsync(ProductBrands);
                }
                if (!_dbContext.ProductTypes.Any())
                {
                   // var ProductTypeData = File.ReadAllText(@"..\Infrastructures\PrecedencesLayer\Data\DataSeed\types.json");
                    var ProductTypeData = File.OpenRead(@"..\Infrastructures\PrecedencesLayer\Data\DataSeed\types.json");
                    //Convert Data To C# Object | Serialization
                    var ProductTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(ProductTypeData);

                    if (ProductTypes is not null && ProductTypes.Any())
                        await _dbContext.ProductTypes.AddRangeAsync(ProductTypes);
                }
                if (!_dbContext.products.Any())
                {
                    //var ProductData = File.ReadAllText(@"..\Infrastructures\PrecedencesLayer\Data\DataSeed\products.json");
                    var ProductData = File.OpenRead(@"..\Infrastructures\PrecedencesLayer\Data\DataSeed\products.json");
                    //Convert Data To C# Object | Serialization
                    var Products = await JsonSerializer.DeserializeAsync<List<Product>>(ProductData);

                    if (Products is not null && Products.Any())
                     await   _dbContext.products.AddRangeAsync(Products);
                }
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
