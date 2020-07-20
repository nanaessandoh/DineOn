using DineOn.Data;
using DineOn.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service
{
    public class OrderCartService
    {
        // Class Members
        public string OrderCartId { get; set; }
        public virtual IEnumerable<OrderItem> OrderItems { get; set; }


        private readonly DineOnDBContext _context;
        public OrderCartService(DineOnDBContext context)
        {
            _context = context;
        }




    }
}
