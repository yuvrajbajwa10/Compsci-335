using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIvCard.Dtos
{
    public class CardOut
    {
        public string Name { get; set; }
        public int Uid { get; set; }
        public string Photo { get; set; }
        public string Categories { get; set; }
        public string PhotoType { get; set; }
    }

}
