using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Order
{
    public class OrderItem : BaseEntity<int>
    {
        public ProductItemOrdered Product { get; set; } = new ProductItemOrdered();
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
  
}
