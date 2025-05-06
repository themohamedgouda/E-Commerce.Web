using Shared.DataTranseferObject.IdentityModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranseferObject.OrderModuleDto
{
    public class OrderToReturnDto
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public DateTimeOffset OrderDate { get; set; }
        public AdderessDto Address { get; set; } = default!;
        public string DelivaryMethod { get; set; } = default!;
        public string OrderStatus { get; set; } = default!;
        public ICollection<OrderItemDto> Items { get; set; } = [];
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
