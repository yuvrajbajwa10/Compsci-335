using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz1.Models
{
    //EnrolmentNum, StudentID and Course
    public class Enrolments
    {
        [Key]
        public int EnrolmentNum { get; set; }
        [Required]
        public string StudentID { get; set; }
        [Required]
        public string Course { get; set; }

    }
}
