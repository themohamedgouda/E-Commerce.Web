using DomainLayer.Models;
using DomainLayer.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace ServicesImplementationLayer.Specifications
{
     class ProductWithBrandAndTypeSpecifications : BaseSpecifications<Product, int>
    {
        public ProductWithBrandAndTypeSpecifications(ProductQueryPrams queryPrams) :
            base(P =>
            (!queryPrams.BrandId.HasValue || P.BrandId == queryPrams.BrandId) &&
            (!queryPrams.TypeId.HasValue || P.TypeId == queryPrams.TypeId))
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            switch (queryPrams.SortingOptions)
            {
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(x => x.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending(x => x.Price);
                    break;
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(x => x.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending(x => x.Name);
                    break;
                default:
                    AddOrderBy(x => x.Id);
                    break;
            }
        }
        public ProductWithBrandAndTypeSpecifications(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
        }
    }
}
