using System.ComponentModel.DataAnnotations;

namespace IdentityWebApp.Models
{
    public class Employee
    {
        public int Id { get; set; } = 0;
        [Required(ErrorMessage = "First Name is Required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "City Name is Required")]
        public string? City { get; set; }
    }
}
