using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Data.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
    }
}
