using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Data.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public double Total { get; set; }
        public string OrderReference { get; set; }
        public bool OrderCompleted { get; set; }
        public DateTime DateCreated { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
