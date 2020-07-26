using DineOn.Data;
using DineOn.Data.Models;
using DineOn.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DineOn.Service
{
    public class CartService : ICart
    {
        private readonly DineOnDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISession _session;

        public CartService(DineOnDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _session = _httpContextAccessor.HttpContext.Session;
        }

        public string GetCartId()
        {
            return _session.GetString("cartId");
        }

        public void AddToCart(MenuItem menuItem, int quantity)
        {
            // Get Session value and time
            var cartId = GetCartId();
            // Check Orders to see if item exist
            var orderCartItem = _context.CartItems
                .SingleOrDefault(asset => asset.MenuItem.MenuItemId == menuItem.MenuItemId && asset.CartId == cartId);

            // If Item does not exist add to the Table
            if (orderCartItem == null)
            {
                orderCartItem = new CartItem
                {
                    MenuItem = menuItem,
                    Quantity = quantity,
                    CartId = cartId
                };

                _context.Add(orderCartItem);
            }
            // If Item exist add new Quantity to existing entry 
            else
            {
                _context.Update(orderCartItem);
                orderCartItem.Quantity += quantity;
            }
            _context.SaveChanges();
        }

        public void RemoveFromCart(int menuItemId)
        {  
            // Get Session Value
            var cartId = GetCartId();
            // Check Orders to see if item exist
            var orderCartItem = _context.CartItems
                .SingleOrDefault(asset => asset.MenuItem.MenuItemId == menuItemId && asset.CartId == cartId);

            // If item exist in cart remove
            if (orderCartItem != null)
            {
                _context.Remove(orderCartItem);
                _context.SaveChanges();
            }
        }

        public IEnumerable<CartItem> GetCartItems()
        {
            // Get Session Value
            var cartId = GetCartId();
            // Return list of items associated with session id
            return _context.CartItems
                .Include(asset => asset.MenuItem)
                .Where(asset => asset.CartId == cartId);
        }


        public int GetCartCount()
        {
            return GetCartItems().Select(asset => asset.Quantity).Sum();
        }


        public double GetCartTotal()
        {
            double total = GetCartItems().Select(asset => asset.MenuItem.Price * asset.Quantity).Sum();
            return Math.Round(total, 2);
        }

        public void ChangeCartItemQuantity(int menuItemId, int quantity)
        {
            // Select Cart Item
            var cartItem = GetCartItem(menuItemId); 
            // If the Item Exist and the quantity is not that same as the new quantity ppdate 
            if(cartItem != null && cartItem.Quantity != quantity)
            {
                _context.Update(cartItem);
                cartItem.Quantity = quantity;
                _context.SaveChanges();
            }
        }

        public CartItem GetCartItem(int menuItemId)
        {
            // Get the Cart Id
            var cartId = GetCartId();
            // Select Cart Item
            return _context.CartItems
                .Include(asset => asset.MenuItem)
                .SingleOrDefault(asset => asset.MenuItem.MenuItemId == menuItemId && asset.CartId == cartId);
        }
    }
}