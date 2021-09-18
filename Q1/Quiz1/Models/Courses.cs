using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz1.Models
{
    //Code, Start1, End1, Weekday1, Location1, Start2, End2, Weekday2 and Location2
    public class Courses
    {
        [Key]
        public string Code { get; set; }
        [Required]
        public string Start1 { get; set; }
        [Required]
        public string End1 { get; set; }
        [Required]
        public string Weekday1 { get; set; }
        [Required]
        public string Location1 { get; set; }
        public string Start2 { get; set; }
        public string End2 { get; set; }
        public string Weekday2 { get; set; }
        public string Location2 { get; set; }

    }
}
