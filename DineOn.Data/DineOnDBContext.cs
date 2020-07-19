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
        public DbSet<Order> Orders { get; set; }
        public DbSet<MenuItemOrder> MenuItemOrders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuItemOrder>()
                .HasKey(mo => new { mo.MenuItemId, mo.OrderId });

            modelBuilder.Entity<MenuItemOrder>()
                .HasOne(mo => mo.MenuItem)
                .WithMany(m => m.MenuItemOrders)
                .HasForeignKey(mo => mo.MenuItemId);

            modelBuilder.Entity<MenuItemOrder>()
                .HasOne(mo => mo.Order)
                .WithMany(o => o.MenuItemOrders)
                .HasForeignKey(mo => mo.OrderId);
        }
    }
 }
