using DineOn.Data;
using DineOn.Data.Models;
using DineOn.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
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


        public void CreateOrder()
        {
            // Delete Orders that are not completed
            DeleteNotCompletedOrders();
            // Create a new order
            CreateNewOrder();
        }


        public void CompleteOrder(string[] details, double total)
        {
            // Migrate Selected Menu Items from CartItem to OrderItem
            MigrateCartToOrder();

            // Update order with details provided on checkout
            UpdateOrderDetails(details,total);

            // Clear the Order Cart
            ClearCart();

            // Save Changes
            _context.SaveChanges();
        }

        public Order GetCurrentOrder() 
        {
            // Get session value
            var orderReference = GetOrderReference();

            // Order created based on Session Id
            return _context.Orders
                .FirstOrDefault(asset => asset.OrderReference == orderReference && asset.OrderCompleted == true);
        }



        // Helper Methods

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

        public void DeleteNotCompletedOrders()
        {
            // Select list of not completed orders
            var notCompletedOrders = _context.Orders
                .Where(asset => asset.OrderCompleted == false);
            // If list is not empty remove them
            if (notCompletedOrders != null && notCompletedOrders.Any())
            {
                _context.RemoveRange(notCompletedOrders);
                _context.SaveChanges();
            }
        }

        public void CreateNewOrder()
        {
            var currentTime = DateTime.Now;
            // Create New Order
            var newOrder = new Order
            {
                Total = 0,
                OrderCompleted = false,
                DateCreated = currentTime,
                OrderReference = GetOrderReference()
            };
            _context.Add(newOrder);
            _context.SaveChanges();
        }

        public void UpdateOrderDetails(string[] details, double total)
        {
            // Get session value
            var orderReference = GetOrderReference();

            // Get the most recent Order created based on Session Id
            var order = _context.Orders
                .OrderByDescending(asset => asset.DateCreated)
                .FirstOrDefault(asset => asset.OrderReference == orderReference);

            _context.Update(order);
            order.FirstName = details[0];
            order.LastName = details[1];
            order.Address = details[2];
            order.City = details[3];
            order.Email = details[4];
            order.OrderCompleted = true;
            order.PostalCode = details[5];
            order.Total = total;

        }

        public void MigrateCartToOrder()
        {
            // Get session value
            var orderReference = GetOrderReference();

            // Get the most recent Order created based on Session Id
            var order = _context.Orders
                .OrderByDescending(asset => asset.DateCreated)
                .FirstOrDefault(asset => asset.OrderReference == orderReference);

            // Get Items in the Cart
            var cartItems = GetCartItems();

            // Migrate Items from CartItem table into OrderItem table
            foreach (var item in cartItems)
            {
                var orderItem = new OrderItem
                {
                    MenuItem = item.MenuItem,
                    Quantity = item.Quantity,
                    Order = order
                };

                _context.Add(orderItem);

            }
        }

        public void ClearCart()
        {
            // Get Items related to session Value
            var cartItems = GetCartItems();
            _context.RemoveRange(cartItems);
            _context.SaveChanges();
        }

    }
}
