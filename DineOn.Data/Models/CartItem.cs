using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Data.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public int Quantity { get; set; }
        public string CartId { get; set; }
    }
}
