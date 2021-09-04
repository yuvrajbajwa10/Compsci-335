using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIvCard.Models;

namespace WebAPIvCard.Data
{
    public interface ICardRepo
    {
        Bear GetBear(int id);
    }
}
