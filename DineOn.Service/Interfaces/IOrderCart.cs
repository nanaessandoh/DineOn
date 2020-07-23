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
        void RemoveFromCart(MenuItem menuItem);
        IEnumerable<OrderItem> GetOrderCartItems();
        void ClearCart();
        double GetOrderCartTotal();
        int GetCartCount();
    }
}
