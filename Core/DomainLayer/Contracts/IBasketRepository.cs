using DomainLayer.Models.Basket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Contracts
{
    public interface IBasketRepository
    {
        Task<CustomerBasket?> GetBasketAsync(string Key);
        Task<CustomerBasket?> UpdateOrCreateBasketAsync(CustomerBasket basket , TimeSpan? time = null);
        Task<bool> DeleteBasketAsync(string Id);
    }
}
