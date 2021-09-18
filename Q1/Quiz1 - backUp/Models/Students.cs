using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz1.Models
{
    // Id and Password
    public class Students
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
