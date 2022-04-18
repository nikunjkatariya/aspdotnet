using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementAPIVSix.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string? CategoryType { get; set; }
        public List<Product> Product = null!;
    }
}
