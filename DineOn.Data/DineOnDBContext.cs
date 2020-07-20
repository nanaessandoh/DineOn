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
        //public DbSet<OrderCart> OrderCarts { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<MenuItemOrder>()
        //        .HasKey(mo => new { mo.MenuItemId, mo.OrderId });

        //    modelBuilder.Entity<MenuItemOrder>()
        //        .HasOne(mo => mo.MenuItem)
        //        .WithMany(m => m.MenuItemOrders)
        //        .HasForeignKey(mo => mo.MenuItemId);

        //    modelBuilder.Entity<MenuItemOrder>()
        //        .HasOne(mo => mo.Order)
        //        .WithMany(o => o.MenuItemOrders)
        //        .HasForeignKey(mo => mo.OrderId);
        //}
    }
 }
