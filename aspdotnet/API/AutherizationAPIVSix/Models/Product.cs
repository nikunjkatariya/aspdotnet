using System.ComponentModel.DataAnnotations;

namespace AutherizationAPIVSix.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? ProductDescription { get; set; }
        [Required]
        public int AvailableQuantity { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
