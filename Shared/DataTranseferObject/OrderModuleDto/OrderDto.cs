using Shared.DataTranseferObject.IdentityModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranseferObject.OrderModuleDto
{
    public class OrderDto
    {
        public string BasketId { get; set; } = string.Empty;
        public int DelivaryMethodId { get; set; }
        public AdderessDto Adderess { get; set; } = default!;

        


    }
}
