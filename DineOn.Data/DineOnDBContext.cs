using DineOn.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Data
{
    public class DineOnDBContext : DbContext
    {
        public DineOnDBContext(DbContextOptions options) : base(options) { }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
