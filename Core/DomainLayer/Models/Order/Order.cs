using DomainLayer.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Models.Order
{
    public class Order : BaseEntity<Guid>
    {
        public Order()
        {
            
        }
        public Order(string userEmail, OrderAddress address, DelivaryMethod delivaryMethod, ICollection<OrderItem> items, decimal subTotal)
        {
            UserEmail = userEmail;
            Address = address;
            DelivaryMethod = delivaryMethod;
            Items = items;
            SubTotal = subTotal;
        }

        public string UserEmail { get; set; } = string.Empty;
        public OrderAddress Address { get; set; } = default!;
        public DelivaryMethod DelivaryMethod { get; set; } = default!;
        public ICollection<OrderItem> Items { get; set; } = [];
        public decimal SubTotal { get; set; }


        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public int DelivaryMethodId { get; set; } // FK
        public OrderStatus OrderStatus { get; set; }
        //[NotMapped]
        //public decimal Total { get => SubTotal + DelivaryMethod.Price;}
        public decimal GetTotal() =>  SubTotal + DelivaryMethod.Price;
       
    }
}
