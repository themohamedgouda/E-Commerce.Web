﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ProductQueryPrams
    {
       public int? TypeId { get; set; }
       public int? BrandId { get; set; }
       public ProductSortingOptions SortingOptions { get; set; }
    }
}
