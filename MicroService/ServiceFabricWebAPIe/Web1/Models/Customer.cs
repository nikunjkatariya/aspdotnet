using System.ComponentModel.DataAnnotations;

namespace Web1.Models
{
    public class Customer
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
    }
}
