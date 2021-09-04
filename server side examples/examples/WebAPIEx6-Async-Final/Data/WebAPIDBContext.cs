using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIEx6.Models;


namespace WebAPIEx6.Data
{
    public class WebAPIDBContext : DbContext
    {
        public WebAPIDBContext(DbContextOptions<WebAPIDBContext> options) : base(options) {}
        public DbSet<Customer> Customers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=MyDatabase.sqlite");
        //}
    }
}
