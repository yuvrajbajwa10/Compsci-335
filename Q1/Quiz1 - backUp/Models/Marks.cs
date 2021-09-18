using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz1.Models
{
    //Id, A1 and A2.
    public class Marks
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float A1 { get; set; }
        [Required]
        public float A2 { get; set; }
    }
}
