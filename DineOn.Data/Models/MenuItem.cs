using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Data.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsTopPick { get; set; }
        public virtual Category Category { get; set; }

    }
}
