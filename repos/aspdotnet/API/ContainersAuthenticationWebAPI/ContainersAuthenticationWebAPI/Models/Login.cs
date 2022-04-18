using System.ComponentModel.DataAnnotations;

namespace ContainersAuthenticationWebAPI.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Username Required")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password Required")]
        public string? Password { get; set; }
    }
}
