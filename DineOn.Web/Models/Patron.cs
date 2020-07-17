using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DineOn.Web.Models
{
    public class Patron
    {
        public int PatronId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string ZipCode { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
