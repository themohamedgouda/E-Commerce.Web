﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Product
{
    public class ProductType : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;

    }
}
