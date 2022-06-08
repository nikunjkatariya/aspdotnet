using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementMVCVSix.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? ProductName { get; set; } = "ABC";
        public string? ManufacturerName { get; set; }
        public string? ManufacturerContact { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Price { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public string? DistributorName { get; set; }
        public int BuildNo { get; set; }
        public string? Street { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        [Required]
        public string? DistributorContact { get; set; }
        public DateTime LastModificationDate { get; set; }= DateTime.Now;
    }
}
