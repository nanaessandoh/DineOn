using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DineOn.Data.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public virtual IEnumerable<MenuItem> MenuItems { get; set; } 
    }
}