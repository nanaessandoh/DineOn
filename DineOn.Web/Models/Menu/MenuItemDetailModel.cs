using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DineOn.Web.Models.Menu
{
    public class MenuItemDetailModel
    {
        public int MenuItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        [Range(1,5)]
        public int rating { get; set; }
        public int NumberOfRatings { get; set; }
        public int AverageRating { get; set; }

    }
}
