﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Basket
{ 
    public class CustomerBasket
    {
        public string Id { get; set; }
        public ICollection<CustomerBasket> Items { get; set; } = [];
    }
}
