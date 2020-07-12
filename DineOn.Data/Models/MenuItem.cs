using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DineOn.Data.Models
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public bool IsTopPick { get; set; }
        [Required]
        public virtual Category Category { get; set; }
        public virtual IEnumerable<Rating> Rating { get; set; }
        public virtual IEnumerable<Comment> Comment { get; set; }
    }
}
