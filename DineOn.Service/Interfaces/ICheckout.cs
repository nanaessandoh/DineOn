using DineOn.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service.Interfaces
{
    public interface ICheckout
    {
        void CreateOrder(Order order);
        IEnumerable<OrderItem> GetOrderItems();
        public double GetOrderTotal();
        public int GetOrderCount();
    }
}
