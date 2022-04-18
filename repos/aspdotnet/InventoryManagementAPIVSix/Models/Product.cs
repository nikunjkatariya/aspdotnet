using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace InventoryManagementAPIVSix.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string? ProductName { get; set; }
        [Required]
        public string? ManufacturerName { get; set; }
        [Required]
        public string? ManufacturerContact { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        [JsonIgnore]
        public int CategoryId { get; set; }
        [Required]
        public string? DistributorName { get; set; }
        [Required]
        public int BuildNo { get; set; }
        public string? Street { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        [Required]
        public string? DistributorContact { get; set; }
        public DateTime LastModificationDate { get; set; } = DateTime.Now;
    }
}
