using Microsoft.AspNetCore.Mvc;
using ServicesAbstractionLayer;
using Shared.DataTranseferObject.BasketModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController(IServicesManager servicesManager ) : ControllerBase
    {
        [HttpGet]

        public async Task<ActionResult<BasketDto>> GetBasket(string id)
        {
            var basket = await servicesManager.BasketServices.GetBasketAsync(id);
           
            return Ok(basket);
        }
        [HttpPost]
        public async Task<ActionResult<BasketDto>> UpdateOrCreateBasket(BasketDto basket)
        {
            var updatedBasket = await servicesManager.BasketServices.UpdateOrCreateBasketAsync(basket);
           
            return Ok(updatedBasket);
        }
        [HttpDelete("{Key}")]
        public async Task<ActionResult<bool>> DeleteBasket(string Key)
        {
            var result = await servicesManager.BasketServices.DeleteBasketAsync(Key);
            
            return Ok(result);
        }
    }
}
