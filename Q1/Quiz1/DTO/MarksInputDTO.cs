using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz1.DTO
{
    public class MarksInputDTO
    {
        [Required]
        public int Id { get; set; }
        public float A1 { get; set; }
        public float A2 { get; set; }
    }
}
