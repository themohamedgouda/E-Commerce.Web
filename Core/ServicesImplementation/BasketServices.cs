using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models.Basket;
using ServicesAbstractionLayer;
using Shared.DataTranseferObject.BasketModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementationLayer
{
    public class BasketServices(IBasketRepository _basketRepository , IMapper _mapper) : IBasketServices
    {
        public async Task<bool> DeleteBasketAsync(string Key)
        {
           return await _basketRepository.DeleteBasketAsync(Key);
        }

        public async Task<BasketDto> GetBasketAsync(string Key)
        {
            var basket = await _basketRepository.GetBasketAsync(Key);
            if (basket != null) return _mapper.Map<CustomerBasket,BasketDto>(basket);
            else throw new BasketNotFoundException(Key);

        }

        public async Task<BasketDto> UpdateOrCreateBasketAsync(BasketDto basket)
        {
            var customerBasket = _mapper.Map<BasketDto,CustomerBasket>(basket);
            var CreatedOrUpdatedBasket =  await _basketRepository.UpdateOrCreateBasketAsync(customerBasket);
            if (CreatedOrUpdatedBasket != null)
             return await GetBasketAsync(basket.Id);
            else
                throw new Exception($"Can Not Update Or Create Basket now Try Again Later");
        }
    }
}
