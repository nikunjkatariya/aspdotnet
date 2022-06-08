using System.ComponentModel.DataAnnotations;

namespace DotNetCoreWebApplication.Models
{
    public class User
    {
        public string? UserId { get; set; } = "";
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }
    }
}
