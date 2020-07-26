using DineOn.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service.Interfaces
{
    public interface ICheckout
    {
        void CreateOrder();

        void CompleteOrder(string[] details, double total);
    }
}
