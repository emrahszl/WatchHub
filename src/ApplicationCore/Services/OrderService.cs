using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketService _basketService;
        private readonly IRepository<Order> _orderRepo;

        public OrderService(IBasketService basketService, IRepository<Order> orderRepo)
        {
            _basketService = basketService;
            _orderRepo = orderRepo;
        }

        public async Task<Order> CreateOrderAsync(string buyerId, Address shippingAddress)
        {
            var basket = await _basketService.GetOrCreateBasketAsync(buyerId);

            Order order = new Order() 
            {
                 ShipToAddress = shippingAddress,
                 BuyerId = buyerId,
                 OrderItems = basket.BasketItems.Select(bi => new OrderItem()
                 {
                    ProductId = bi.ProductId,
                    ProductName = bi.Product.ProductName,
                    UnitPrice = bi.Product.ProductPrice,
                    PictureUri = bi.Product.PictureUri,
                    Quantity = bi.Quantity
                 }).ToList()
            };

            return await _orderRepo.AddAsync(order);
        }
    }
}
