using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIvCard.Models;

namespace WebAPIvCard.Data
{
    public class CardRepo : ICardRepo
    {
        private readonly CardDbContext _cardDbContext;

        public CardRepo(CardDbContext cardDbContext)
        {
            _cardDbContext = cardDbContext;
        }
        public Bear GetBear(int id)
        {
            Bear bear = _cardDbContext.Bears.FirstOrDefault(e => e.Id == id);
            return bear;
        }
    }
}
