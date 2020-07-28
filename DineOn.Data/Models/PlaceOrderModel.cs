using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DineOn.Data.Models
{
    public class PlaceOrderModel
    {
        [Required(ErrorMessage = "Valid first name is required")]
        [MinLength(2, ErrorMessage = "Invalid first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Valid last name is required")]
        [MinLength(2, ErrorMessage = "Invalid last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a valid email address for delivery updates and restaurant offers")]
        [EmailAddress(ErrorMessage = "Ivalid email address format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Valid address is required for delivery")]
        [MinLength(2, ErrorMessage = "Invalid address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Valid city is required for delivery")]
        public string City { get; set; }
        [Required(ErrorMessage = "Valid postcode is required for delivery")]
        [MinLength(6, ErrorMessage = "Invalid postcode")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Please enter full name as it appears on card")]
        [MinLength(2, ErrorMessage = "Invalid full name")]
        public string CardName { get; set; }
        [Required(ErrorMessage = "Please enter card number as it appears on card")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Card number is 16 digits")]
        public string CardNumber { get; set; }
        [Required(ErrorMessage = "Please enter card expiry date as it appears on card")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Enter card expiry in the format MMYY")]
        public string CardExpiration { get; set; }
        [Required(ErrorMessage = "Please enter CVV as it appears on the back of the card")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Please enter a valid CVV (3 digits)")]
        public string CardCVV { get; set; }
    }
}
