using DineOn.Data.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service.Interfaces
{
    public interface IOrderCart
    {
        string GetCartId();
        void AddToCart(MenuItem menuItem, int quantity);
        OrderItem GetCartItem(int menuItemId);
        void ChangeCartItemQuantity(int menuItemId, int quantity);
        void RemoveFromCart(int menuItemId);
        IEnumerable<OrderItem> GetOrderCartItems();
        void ClearCart();
        double GetOrderCartTotal();
        int GetCartCount();
    }
}
