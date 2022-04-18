using System.ComponentModel.DataAnnotations;

namespace InvoiceGenerater.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string? ClientName { get; set; }
        [Required]
        public string? ClientGST { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? State { get; set; }
        [Required]
        public string? PinCode { get; set; }
        [Required]
        public string? PANNumber { get; set; }
        [Required]
        public string? ContactNumber { get; set; }
    }
}
