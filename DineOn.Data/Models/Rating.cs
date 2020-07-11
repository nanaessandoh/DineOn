using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DineOn.Data.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        [Range(1,5)]
        public int RatingValue { get; set; }

    }
}
