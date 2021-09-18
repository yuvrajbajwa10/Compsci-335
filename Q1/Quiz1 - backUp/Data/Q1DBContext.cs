using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Quiz1.Models;


namespace Quiz1.Data
{
    public class Q1DBContext: DbContext
    {

        public Q1DBContext(DbContextOptions<Q1DBContext> options) : base(options) { }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Enrolments> Enrolments { get; set; }
        public DbSet<Marks> Marks { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Students> Students { get; set; }

    }
}
