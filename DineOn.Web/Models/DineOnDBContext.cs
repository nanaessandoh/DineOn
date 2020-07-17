using DineOn.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DineOn.Web.Models
{
    public class DineOnDBContext: DbContext
    {
        public DineOnDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Patron> Patrons { get; set; }
    }
}
