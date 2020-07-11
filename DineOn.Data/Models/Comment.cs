using System;
using System.ComponentModel.DataAnnotations;

namespace DineOn.Data.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        [Required]
        public virtual MenuItem MenuItem {get; set;}
        [Required]
        public virtual Patron Patron { get; set; }
        [Required]
        public DateTime PostTime{ get; set; }
        [Required]
        public string PostEntry { get; set; }

    }
}