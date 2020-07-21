using DineOn.Data;
using DineOn.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DineOn.Service
{
    public class OrderCart
    {
        private readonly DineOnDBContext _context;
        private OrderCart(DineOnDBContext context)
        {
            _context = context;
        }

        public string OrderCartId { get; set; }
        public virtual IEnumerable<OrderItem> OrderItems { get; set; }

        public static OrderCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<DineOnDBContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new OrderCart(context) {OrderCartId = cartId };
        }


        public void AddToCart(MenuItem menuItem, int quantity)
        {
            var currentTime = DateTime.Now;
            // Check Orders to see if item exist
            var orderCartItem = _context.OrderItems
                .SingleOrDefault(asset => asset.MenuItem.MenuItemId == menuItem.MenuItemId && asset.OrderCartId == OrderCartId);

            // If Item does not exist add to the Table
            if (orderCartItem == null)
            {
                orderCartItem = new OrderItem
                {
                    MenuItem = menuItem,
                    Quantity = quantity,
                    OrderCartId = OrderCartId,
                    DateCreated = currentTime
                };

                _context.Add(orderCartItem);
            }
            // If Item exist add new Quantity to existing entry 
            else
            {
                orderCartItem.Quantity += quantity;
            }
            _context.SaveChanges();
        }

        public void RemoveFromCart(MenuItem menuItem)
        {
            // Check Orders to see if item exist
            var orderCartItem = _context.OrderItems
                .SingleOrDefault(asset => asset.MenuItem.MenuItemId == menuItem.MenuItemId && asset.OrderCartId == OrderCartId);

            // If item exist in cart remove
            if (orderCartItem != null)
            {
                _context.Remove(orderCartItem);
            }
        }

        public IEnumerable<OrderItem> GetOrderCartItems()
        {
            return _context.OrderItems
                .Include(asset => asset.MenuItem)
                .Where(asset => asset.OrderCartId == OrderCartId);
        }


        public void ClearCart()
        {
            var cartItems = GetOrderCartItems();
            _context.RemoveRange(cartItems);
            _context.SaveChanges();
        }


        public double GetOrderCartTotal()
        {
            double total = GetOrderCartItems().Select(asset => asset.MenuItem.Price * asset.Quantity).Sum();
            return total;
        }

    }
}
