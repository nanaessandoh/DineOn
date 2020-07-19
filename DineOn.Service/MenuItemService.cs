using DineOn.Data;
using DineOn.Data.Models;
using DineOn.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DineOn.Service
{
    public class MenuItemService : IMenuItem
    {
        private readonly DineOnDBContext _context;
        public MenuItemService(DineOnDBContext context)
        {
            _context = context;
        }

        public IEnumerable<MenuItem> GetEntireMenu()
        {
            return _context.MenuItems
                .Include(asset => asset.Category);
        }

        public IEnumerable<MenuItem> GetBurgers()
        {
            return GetEntireMenu().Where(asset => asset.Category.CategoryId == 2);
        }

        public IEnumerable<MenuItem> GetDesserts()
        {
            return GetEntireMenu().Where(asset => asset.Category.CategoryId == 6);
        }

        public IEnumerable<MenuItem> GetMexican()
        {
            return GetEntireMenu().Where(asset => asset.Category.CategoryId == 3);
        }

        public IEnumerable<MenuItem> GetPizzas()
        {
            return GetEntireMenu().Where(asset => asset.Category.CategoryId == 4);
        }

        public IEnumerable<MenuItem> GetStarters()
        {
            return GetEntireMenu().Where(asset => asset.Category.CategoryId == 1);
        }

        public IEnumerable<MenuItem> GetVegetarian()
        {
            return GetEntireMenu().Where(asset => asset.Category.CategoryId == 5);
        }

        public MenuItem GetMenuItem(int menuItemId)
        {
            return GetEntireMenu().FirstOrDefault(asset => asset.MenuItemId == menuItemId);
        }

        public void AddRating(int menuItemId, int rating)
        {
            var menuItem = GetMenuItem(menuItemId);

            var entry = new Rating
            {
                MenuItem = menuItem,
                Value = rating
            };

            _context.Add(entry);
            _context.SaveChanges();
        }

        public int GetAverageRating(int menuItemId)
        {
            var list = GetRatings(menuItemId);
            if (list != null && list.Any())
            {
                return Convert.ToInt32(list.Average());
            }
            return 0;
        }

        public int GetNumberOfRatings(int menuItemId)
        {
            var list = GetRatings(menuItemId);
            if (list != null && list.Any())
            {
                return list.Count();
            }
            return 0;
        }

        // Helper Menthod
        public IEnumerable<int> GetRatings(int menuItemId)
        {
            return _context.Ratings
                .Where(asset => asset.MenuItem.MenuItemId == menuItemId)
                .Select(asset => asset.Value);
        }

    }
}
