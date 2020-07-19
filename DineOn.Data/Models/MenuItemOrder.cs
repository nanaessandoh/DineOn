using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Data.Models
{
    public class MenuItemOrder
    {
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
