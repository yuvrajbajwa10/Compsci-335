using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIvCard.Models;

namespace WebAPIvCard.Data
{
    public class CardDbContext : DbContext
    {
        public CardDbContext(DbContextOptions<CardDbContext> options) : base(options) { }
        public DbSet<Bear> Bears { get; set; }
    }
}
