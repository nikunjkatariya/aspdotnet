using System.ComponentModel.DataAnnotations;

namespace ContainerAuthenticationWithMVC.Models
{
    public class Container
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Container Code Required")]
        public string? ContainerCode { get; set; }
        [Required(ErrorMessage ="Terminal Name Required")]
        public string? TerminalName { get; set; }
    }
}
