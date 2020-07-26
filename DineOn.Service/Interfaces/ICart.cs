using DineOn.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service.Interfaces
{
    public interface ICart
    {
        string GetCartId();
        void AddToCart(MenuItem menuItem, int quantity);
        CartItem GetCartItem(int menuItemId);
        void ChangeCartItemQuantity(int menuItemId, int quantity);
        void RemoveFromCart(int menuItemId);
        IEnumerable<CartItem> GetCartItems();
        double GetCartTotal();
        int GetCartCount();
    }
}
