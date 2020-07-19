using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public List<MenuItem> Cart { get; set; }
    }
}
