using System.Collections;
using System.Collections.Generic;

namespace DineOn.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<MenuItem> MenuItems { get; set; } 
    }
}