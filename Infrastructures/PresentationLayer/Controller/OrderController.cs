using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstractionLayer;
using Shared.DataTranseferObject.OrderModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controller
{
    public class OrderController(IServicesManager _servicesManager) : APIBaseController
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder([FromBody] OrderDto orderDto)
        {
            var Email = GetUserEmailFromToken();
            var order = await _servicesManager.OrderServices.CreateOrderAsync(orderDto, Email);
            return Ok(order);
        }
        [HttpGet("DelivaryMethods")]
        public async Task<ActionResult<IEnumerable<DeliveryMethodDto>>> GetDelivaryMethods()
        {
            var delivaryMethods = await _servicesManager.OrderServices.ge;
            return Ok(delivaryMethods);

        }

    }
}
