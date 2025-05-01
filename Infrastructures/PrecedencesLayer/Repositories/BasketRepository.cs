using DomainLayer.Models.Basket;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PrecedencesLayer.Repositories
{
    public class BasketRepository(IConnectionMultiplexer connection) : IBasketRepository
    {
        private readonly IDatabase _database = connection.GetDatabase();

        public async Task<bool> DeleteBasketAsync(string Id)
        {
             return await _database.KeyDeleteAsync(Id);
        }
        public async Task<CustomerBasket?> GetBasketAsync(string Key)
        {
            var Basket = await _database.StringGetAsync(Key);

            if (Basket.IsNullOrEmpty) return null;

            return JsonSerializer.Deserialize<CustomerBasket>(Basket!);
        }



        public async Task<CustomerBasket?> UpdateOrCreateBasketAsync(CustomerBasket basket, TimeSpan? time = null)
        {
            var JsonBasket = JsonSerializer.Serialize(basket);
            var IsCreatedOrUpdated = await _database.StringSetAsync(basket.Id, JsonBasket, time ?? TimeSpan.FromDays(30)  );
            if (IsCreatedOrUpdated)
                 return await GetBasketAsync(basket.Id);        
            else
                return null;
        }
    }
    
}
