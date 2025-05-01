using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTranseferObject.BasketModuleDto
{
    public class BasketItemDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
        [Range(1,double.MaxValue)]
        public decimal Price { get; set; }
        [Range(1, 100)]
        public int Quantity { get; set; }

    }
}
