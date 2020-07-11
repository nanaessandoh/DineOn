namespace DineOn.Data.Models
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