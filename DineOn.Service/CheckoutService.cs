using DineOn.Data;
using DineOn.Data.Models;
using DineOn.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DineOn.Service
{
    public class CheckoutService : ICheckout
    {
        private readonly DineOnDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;

        public CheckoutService(DineOnDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }

        public string GetOrderReference()
        {
            return _session.GetString("cartId");
        }

        public IEnumerable<CartItem> GetCartItems()
        {
            // Get Session Value
            var cartId = GetOrderReference();
            // Return list of items associated with session id
            return _context.CartItems
                .Include(asset => asset.MenuItem)
                .Where(asset => asset.CartId == cartId);
        }


        public IEnumerable<OrderItem> GetOrderItems()
        {
            // Get Session Value
            var orderReference = GetOrderReference();
            // Return list of items associated with session id
            return _context.OrderItems
                .Include(asset => asset.MenuItem)
                .Where(asset => asset.OrderReference == orderReference);
        }

        public double GetOrderTotal()
        {
            double total = GetOrderItems().Select(asset => asset.MenuItem.Price * asset.Quantity).Sum();
            return Math.Round(total + 3.49 + (0.15 * total) , 2);
        }

        public int GetOrderCount()
        {
            return GetOrderItems().Select(asset => asset.Quantity).Sum();
        }

        public void CreateOrder(Order order)
        {

            var orderReference = GetOrderReference();

            // Delete Any Existing Order
            var existingOrder = _context.Orders
                .SingleOrDefault(asset => asset.OrderReference == orderReference);

            if (existingOrder != null)
            {
                _context.Remove(existingOrder);
            }

            // Get Items in the Cart
            var cartItems = GetCartItems();

            foreach (var item in cartItems)
            {
                // Check if item exist in Order Item table
                var cartItem = _context.OrderItems
                    .SingleOrDefault(asset => asset.MenuItem.MenuItemId == item.MenuItem.MenuItemId && asset.OrderReference == orderReference);

                // If Item does not exist add to the Order Table
                if (cartItem == null)
                {
                    cartItem = new OrderItem
                    {
                        MenuItem = item.MenuItem,
                        Quantity = item.Quantity,
                        OrderReference = orderReference,
                        Order = order 
                    };
                    _context.Add(cartItem);
                }
                // If Item exist check if Quantity is different and Update 
                else if (item.Quantity != cartItem.Quantity )
                {
                    _context.Update(cartItem);
                    cartItem.Quantity = item.Quantity;
                }
            }

            // Get Order Total
            order.Total = GetOrderTotal();
            order.OrderReference = GetOrderReference();

            _context.SaveChanges();


        }

    }
}
