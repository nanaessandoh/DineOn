using DineOn.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service.Interfaces
{
    public interface ICheckout
    {
        void CreateOrder(string cartId);
        Order GetCurrentOrder(string cartId);
        void CompleteOrder(string[] details, double total, string cartId);
    }
}
