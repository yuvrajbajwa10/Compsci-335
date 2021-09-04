using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHIT_Web_API_A1_YBAJ161.Dtos
{
    public class StaffInputDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string Title { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Tel { get; set; }
        public string Url { get; set; }
        public string Research { get; set; }

    }
}
