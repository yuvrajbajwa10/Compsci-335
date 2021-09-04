using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SHIT_Web_API_A1_YBAJ161.Models;

namespace SHIT_Web_API_A1_YBAJ161.Data
{
    public class ShitWebAPIDBContext : DbContext
    {
        public ShitWebAPIDBContext(DbContextOptions<ShitWebAPIDBContext> options) : base(options) { }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Comments> Comments { get; set; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
        //}

    }
}
