using System.ComponentModel.DataAnnotations;

namespace WithAuthorizationWithSwagger.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]  
        public string? Username { get; set; }
        [Required(ErrorMessage="Password Required")]
        public string? Password { get; set; }
    }
}
