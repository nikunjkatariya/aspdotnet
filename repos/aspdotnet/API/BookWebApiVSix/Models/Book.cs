using System.ComponentModel.DataAnnotations;

namespace BookWebApiVSix.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AutherName { get; set; }
        public decimal Price { get; set; }
    }
}
