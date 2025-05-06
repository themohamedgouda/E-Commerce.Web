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
    [Authorize]
    public class OrderController(IServicesManager _servicesManager) : APIBaseController
    {
        [HttpPost]
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder([FromBody] OrderDto orderDto)
        {
            var Email = GetUserEmailFromToken();
            var order = await _servicesManager.OrderServices.CreateOrderAsync(orderDto, Email);
            return Ok(order);
        }
        [AllowAnonymous]
        [HttpGet("DelivaryMethods")]
        public async Task<ActionResult<IEnumerable<DeliveryMethodDto>>> GetDelivaryMethods()
        {
            var delivaryMethods = await _servicesManager.OrderServices.GetDelivaryMethodsAsync();
            return Ok(delivaryMethods);
        }

        [HttpGet()]
        public async Task<ActionResult<OrderToReturnDto>> GetAllOrder()
        {
            var Email = GetUserEmailFromToken();
            var order = await _servicesManager.OrderServices.GetAllOrdersAsync(Email);
            return Ok(order);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderToReturnDto>> GetOrderById(Guid id)
        {
            var order = await _servicesManager.OrderServices.GetOrderByIdAsync(id);
            return Ok(order);
        }

    }
}
