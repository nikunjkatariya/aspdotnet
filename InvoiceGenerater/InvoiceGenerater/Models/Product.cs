using System.ComponentModel.DataAnnotations;

namespace InvoiceGenerater.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
    }
}
