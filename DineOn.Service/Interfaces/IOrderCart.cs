using DineOn.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service.Interfaces
{
    public interface IOrderCart
    {
        OrderCartService GetCart(IServiceProvider services);
        void AddToCart(MenuItem menuItem, int quantity);
        void RemoveFromCart(MenuItem menuItem);
        IEnumerable<OrderItem> GetOrderCartItems();
        void ClearCart();
        double GetOrderCartTotal();
    }
}
