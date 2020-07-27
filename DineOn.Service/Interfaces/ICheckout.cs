using DineOn.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service.Interfaces
{
    public interface ICheckout
    {
        void CreateOrder();
        Order GetCurrentOrder();
        void CompleteOrder(string[] details, double total);
    }
}
