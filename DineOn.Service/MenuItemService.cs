using DineOn.Data;
using DineOn.Data.Models;
using DineOn.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DineOn.Service
{
    public class MenuItemService : IMenuItem
    {
        // Create DbContext private field  
        private readonly DineOnDBContext _context;
        // Constructor
        public MenuItemService(DineOnDBContext context)
        {
            _context = context;
        }
        public void Add(MenuItem newMenuItem)
        {
            _context.Add(newMenuItem);
            _context.SaveChanges();
        }

        public IEnumerable<MenuItem> GetAll()
        {
            return _context.MenuItems
                .Include(asset => asset.Category)
                .Include(asset => asset.Rating);

        }

        public IEnumerable<MenuItem> GetAllTopPicks()
        {
            return GetAll()
                .Where(asset => asset.IsTopPick == true);
        }

        public IEnumerable<MenuItem> GetAvailableMenu()
        {
            return GetAll()
                .Where(asset => asset.IsAvailable == true);

        }

        public IEnumerable<MenuItem> GetByCategoryName(string categoryName)
        {
            return GetAll().Where(asset => asset.Category.Name == categoryName);
        }

        public MenuItem GetById(int menuItemId)
        {
            return GetAll()
                .FirstOrDefault(asset => asset.MenuItemId == menuItemId);
        }

    }
}
