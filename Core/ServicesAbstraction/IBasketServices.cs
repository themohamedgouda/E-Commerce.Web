using Shared.DataTranseferObject.BasketModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstractionLayer
{
    public interface IBasketServices
    {
        Task<BasketDto> GetBasketAsync(string Key);
        Task<BasketDto> UpdateOrCreateBasketAsync(BasketDto basket);
        Task<bool> DeleteBasketAsync(string Key);




    }
}
