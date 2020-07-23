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
    public class OrderCartService : IOrderCart
    {
        private readonly DineOnDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;

        public OrderCartService(DineOnDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }

        public void SetCardId()
        {
            _session.SetString("cartId", Guid.NewGuid().ToString());
        }

        public string GetCartId()
        {
            return _session.GetString("cartId");
        }



        public void AddToCart(MenuItem menuItem, int quantity)
        {
            // Check 
            var cartId = GetCartId();
            if (cartId == null)
            {
                SetCardId();
                cartId = GetCartId();
            }
            var currentTime = DateTime.Now;
            // Check Orders to see if item exist
            var orderCartItem = _context.OrderItems
                .SingleOrDefault(asset => asset.MenuItem.MenuItemId == menuItem.MenuItemId && asset.OrderCartId == cartId);

            // If Item does not exist add to the Table
            if (orderCartItem == null)
            {
                orderCartItem = new OrderItem
                {
                    MenuItem = menuItem,
                    Quantity = quantity,
                    OrderCartId = cartId,
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
            var cartId = GetCartId();
            // Check Orders to see if item exist
            var orderCartItem = _context.OrderItems
                .SingleOrDefault(asset => asset.MenuItem.MenuItemId == menuItem.MenuItemId && asset.OrderCartId == cartId);

            // If item exist in cart remove
            if (orderCartItem != null)
            {
                _context.Remove(orderCartItem);
            }
        }

        public IEnumerable<OrderItem> GetOrderCartItems()
        {
            var cartId = GetCartId();
            return _context.OrderItems
                .Include(asset => asset.MenuItem)
                .Where(asset => asset.OrderCartId == cartId);
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