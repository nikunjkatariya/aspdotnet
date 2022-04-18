using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace XunitWebAPPMVCVSix.Models
{
    [Table("Employee")]
    public class Employee
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Age is Required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Acocunt Number is Required")]
        public string? AccountNumber { get; set; }
    }
}
