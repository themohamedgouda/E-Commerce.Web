using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductQueryPrams
    {
        private const int DefualtPageSize = 5;
        private const int MaxPageSize = 10;
        public int? TypeId { get; set; }
       public int? BrandId { get; set; }
       public ProductSortingOptions SortingOptions { get; set; }
       public string? SearchValue { get; set; }
        public int PageIndex { get; set; } = 1;

        private int pagesize = DefualtPageSize;

        public int PageSize
        {
            get { return pagesize; }
            set { pagesize = value > MaxPageSize ? MaxPageSize : value; }
        }



    }
}
