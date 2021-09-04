using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHIT_Web_API_A1_YBAJ161.Models
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public string Name{ get; set; }
        public string Time{ get; set; }
        public string IP { get; set; }

    }
}
