using System.ComponentModel.DataAnnotations;

namespace InventoryManagementMVCVSix.Models
{
    public class Login
    {
        public int id { get; set; }
        [Required]
        public string? username { get; set; }
        [Required]
        public string? password { get; set; }
    }
}
