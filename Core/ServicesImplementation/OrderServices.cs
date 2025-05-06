using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Exceptions;
using DomainLayer.Models.Basket;
using DomainLayer.Models.Order;
using DomainLayer.Models.Product;
using ServicesAbstractionLayer;
using Shared.DataTranseferObject.IdentityModuleDto;
using Shared.DataTranseferObject.OrderModuleDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesImplementationLayer
{
    public class OrderServices(IMapper _mapper , IBasketRepository _basketRepository , IUnitOfWork _unitOfWork) : IOrderServices
    {
        public async Task<OrderToReturnDto> CreateOrderAsync(OrderDto orderDto, string email)
        {

            var OrderAddress = _mapper.Map<AdderessDto, OrderAddress>(orderDto.Adderess);
            var Basket = await _basketRepository.GetBasketAsync(orderDto.BasketId) ?? throw new BasketNotFoundException(orderDto.BasketId);
            List<OrderItem> orderItems = [];
            var ProductRepo = _unitOfWork.GetRepository<Product,int>();
            foreach (var item in Basket.Items)
            {
                var product = await ProductRepo.GetByIdAsync(item.Id) ?? throw new ProductNotFoundException(item.Id);

                var OrderItem = CreateOrderItem(item, product);

            }
            var DelivaryMethod = await _unitOfWork.GetRepository<DelivaryMethod, int>().GetByIdAsync(orderDto.DelivaryMethodId) ?? throw new DeliveryMethodNotFoundException(orderDto.DelivaryMethodId);
            var SubTotal = orderItems.Sum(item => item.Price * item.Quantity);
            var Order = new Order(email, OrderAddress, DelivaryMethod, orderItems, SubTotal);
            await _unitOfWork.GetRepository<Order, Guid>().AddAsync(Order);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<Order, OrderToReturnDto>(Order);

        }
        private static OrderItem CreateOrderItem(BasketItem item, Product product)
        {
            return new OrderItem()
            {
                Product = new ProductItemOrdered()
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    PictureUrl = product.PictureUrl
                },
                Price = product.Price,
                Quantity = item.Quantity
            };
        }
    }
}
