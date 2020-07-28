using DineOn.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service.Interfaces
{
    public interface ICart
    {
        void AddToCart(MenuItem menuItem, int quantity, string cartId);
        CartItem GetCartItem(int menuItemId, string cartId);
        void ChangeCartItemQuantity(int menuItemId, int quantity, string cartId);
        void RemoveFromCart(int menuItemId, string cartId);
        IEnumerable<CartItem> GetCartItems(string cartId);
        double GetCartTotal(string cartId);
        int GetCartCount(string cartId);
    }
}
