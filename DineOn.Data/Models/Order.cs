using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public virtual List<MenuItemOrder> MenuItemOrders { get; set; }
    }
}
