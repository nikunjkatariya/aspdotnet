using System.ComponentModel.DataAnnotations;

namespace PortMVCAppVThree.Models
{
    public class Ports
    {
        public int Id { get; set; }
        public long PortId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
