using System;
using System.ComponentModel.DataAnnotations;

namespace UserDetailsWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
    }
}
