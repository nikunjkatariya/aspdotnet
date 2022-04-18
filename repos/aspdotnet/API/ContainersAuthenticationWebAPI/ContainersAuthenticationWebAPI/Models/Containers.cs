using System.ComponentModel.DataAnnotations;

namespace ContainersAuthenticationWebAPI.Models
{
    public class Containers
    {
        public int Id { get; set; }
        [Required]
        public string ContainerID { get; set; }
        [Required]
        public string ContainerType { get; set; }
    }
}
