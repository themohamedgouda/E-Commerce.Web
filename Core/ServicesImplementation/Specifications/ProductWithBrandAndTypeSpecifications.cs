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
        public ProductWithBrandAndTypeSpecifications(int? BrandId, int? TypeId, ProductSortingOptions sortingOptions) :
            base(P =>
            (!BrandId.HasValue || P.BrandId == BrandId) &&
            (!TypeId.HasValue || P.TypeId == TypeId))
        {
            AddInclude(x => x.ProductBrand);
            AddInclude(x => x.ProductType);
            switch (sortingOptions)
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
