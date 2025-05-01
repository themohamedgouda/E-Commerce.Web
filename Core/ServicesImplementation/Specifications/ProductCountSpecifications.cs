using DomainLayer.Models.Product;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementationLayer.Specifications
{
    class ProductCountSpecifications : BaseSpecifications<Product, int>
    {
        public ProductCountSpecifications(ProductQueryPrams queryPrams) : base(P =>
            (!queryPrams.BrandId.HasValue || P.BrandId == queryPrams.BrandId) &&
            (!queryPrams.TypeId.HasValue || P.TypeId == queryPrams.TypeId) &&
            (string.IsNullOrEmpty(queryPrams.SearchValue) || P.Name.ToLower().Contains(queryPrams.SearchValue.ToLower())))
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


    }
}
