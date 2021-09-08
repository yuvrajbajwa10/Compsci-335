using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Asignment_2SHITWEBAPI.Models;


namespace Asignment_2SHITWEBAPI.Data
{
    public class SHITDBContext : DbContext
    {

        public SHITDBContext(DbContextOptions<SHITDBContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }

    }
}
