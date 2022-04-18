using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortWithTestingAPP.Models
{
    [Table("port")]
    public class Port
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Port Name is Required")]
        public string? PortName { get; set; }
        [Required(ErrorMessage = "Port Number is Required")]
        public int PortId { get; set; }
    }
}
