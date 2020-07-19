using System.ComponentModel.DataAnnotations;

namespace DineOn.Data.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        [Range(1, 5)]
        public int Value { get; set; }
        public virtual MenuItem MenuItem {get; set;}


    }
}