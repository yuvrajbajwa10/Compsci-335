using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuthenticationEx2.Model;

namespace AuthenticationEx2.Data
{
    public class AuthDbContext:DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
    }
}
