using System.ComponentModel.DataAnnotations;

namespace InvoiceGenerater.Models
{
    public class InvoiceProduct
    {
        public int Id { get; set; }
        public string? InvoiceId { get; set; }
        public Product? Product { get; set; }
        public int ProductId { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        public decimal Discount { get; set; }
        [Required]
        public decimal ProductTax { get; set; }
/*        public decimal ProductAmount => Product.ProductPrice * ProductQuantity;*/
    }
}
