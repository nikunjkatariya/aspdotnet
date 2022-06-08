using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WcfService
{
    public class User
    {
        public string userId { get; set; } = "";
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        public string country { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string contact { get; set; }
    }
}