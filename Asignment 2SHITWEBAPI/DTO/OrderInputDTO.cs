using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asignment_2SHITWEBAPI.DTO
{
    public class OrderInputDTO
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }

    }
}
