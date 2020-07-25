using DineOn.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DineOn.Data
{
    public class DineOnDBContext : DbContext
    {
        public DineOnDBContext(DbContextOptions options) : base(options) { }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rating> Ratings  { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
 }
