using Shared;
using Shared.DataTranseferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstractionLayer
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync(int? BrandId , int? TypeId , ProductSortingOptions sortingOptions);
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();
    }
}
