using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Data.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public virtual Category Category { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; } = 0;
        public double Price { get; set; }
        public virtual List<Rating> Ratings { get; set; }
        public virtual List<MenuItemOrder> MenuItemOrders { get; set; }
    }
}
