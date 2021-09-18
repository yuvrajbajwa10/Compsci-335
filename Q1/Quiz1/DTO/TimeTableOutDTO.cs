using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz1.Models;

namespace Quiz1.DTO
{
    public class TimeTableOutDTO
    {
        public string sId { get; set; }
        public IEnumerable<Courses> Courses { get; set; }
    }
}
