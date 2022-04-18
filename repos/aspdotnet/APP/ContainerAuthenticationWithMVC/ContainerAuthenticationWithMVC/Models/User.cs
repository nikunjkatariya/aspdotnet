using System.ComponentModel.DataAnnotations;

namespace ContainerAuthenticationWithMVC.Models
{
    public class User
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? UserType { get; set; }
        public string? Token { get; set; }
    }
}
