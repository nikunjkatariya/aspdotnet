using System.ComponentModel.DataAnnotations;

namespace InvoiceGenerater.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [Required]
        public string? InvoiceId { get; set; }
        public Client? Client { get; set; }
        public int ClientId { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public DateTime LastDate { get; set; } = DateTime.Now;
    }
}
