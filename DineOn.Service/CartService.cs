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

        public CartService(DineOnDBContext context)
        {
            _context = context;
        }

       
        public void AddToCart(MenuItem menuItem, int quantity, string cartId)
        {
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

        public void RemoveFromCart(int menuItemId, string cartId)
        {  
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

        public IEnumerable<CartItem> GetCartItems(string cartId)
        {
            // Return list of items associated with session id
            return _context.CartItems
                .Include(asset => asset.MenuItem)
                .Where(asset => asset.CartId == cartId);
        }

        public int GetCartCount(string cartId)
        {
            return GetCartItems(cartId).Select(asset => asset.Quantity).Sum();
        }

        public double GetCartTotal(string cartId)
        {
            double total = GetCartItems(cartId).Select(asset => asset.MenuItem.Price * asset.Quantity).Sum();
            return Math.Round(total, 2);
        }

        public void ChangeCartItemQuantity(int menuItemId, int quantity, string cartId)
        {
            // Select Cart Item
            var cartItem = GetCartItem(menuItemId, cartId); 
            // If the Item Exist and the quantity is not that same as the new quantity ppdate 
            if(cartItem != null && cartItem.Quantity != quantity)
            {
                _context.Update(cartItem);
                cartItem.Quantity = quantity;
                _context.SaveChanges();
            }
        }

        public CartItem GetCartItem(int menuItemId, string cartId)
        {
            // Select Cart Item
            return _context.CartItems
                .Include(asset => asset.MenuItem)
                .SingleOrDefault(asset => asset.MenuItem.MenuItemId == menuItemId && asset.CartId == cartId);
        }
    }
}