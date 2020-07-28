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

        public CheckoutService(DineOnDBContext context)
        {
            _context = context;
        }


        public void CreateOrder(string cartId)
        {
            // Delete Orders that are not completed
            DeleteNotCompletedOrders();
            // Create a new order
            CreateNewOrder(cartId);
        }


        public void CompleteOrder(string[] details, double total, string cartId)
        {
            // Migrate Selected Menu Items from CartItem to OrderItem
            MigrateCartToOrder(cartId);

            // Update order with details provided on checkout
            UpdateOrderDetails(details,total, cartId);

            // Clear the Order Cart
            ClearCart(cartId);

            // Save Changes
            _context.SaveChanges();
        }

        public Order GetCurrentOrder(string cartId) 
        {
            // Order created based on Session Id
            return _context.Orders
                .FirstOrDefault(asset => asset.OrderReference == cartId && asset.OrderCompleted == true);
        }


        // Helper Methods


        public IEnumerable<CartItem> GetCartItems(string cartId)
        {
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

        public void CreateNewOrder(string cartId)
        {
            var currentTime = DateTime.Now;
            // Create New Order
            var newOrder = new Order
            {
                Total = 0,
                OrderCompleted = false,
                DateCreated = currentTime,
                OrderReference = cartId
            };
            _context.Add(newOrder);
            _context.SaveChanges();
        }

        public void UpdateOrderDetails(string[] details, double total, string cartId)
        {
            // Get the most recent Order created based on Session Id
            var order = _context.Orders
                .OrderByDescending(asset => asset.DateCreated)
                .FirstOrDefault(asset => asset.OrderReference == cartId);

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

        public void MigrateCartToOrder(string cartId)
        {

            // Get the most recent Order created based on Session Id
            var order = _context.Orders
                .OrderByDescending(asset => asset.DateCreated)
                .FirstOrDefault(asset => asset.OrderReference == cartId);

            // Get Items in the Cart
            var cartItems = GetCartItems(cartId);

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

        public void ClearCart(string cartId)
        {
            // Get Items related to session Value
            var cartItems = GetCartItems(cartId);
            _context.RemoveRange(cartItems);
            _context.SaveChanges();
        }

    }
}
