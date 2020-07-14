﻿using DineOn.Data;
using DineOn.Data.Models;
using DineOn.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DineOn.Service
{
    public class RatingService : IRating
    {
        // Create DbContext private field  
        private readonly DineOnDBContext _context;
        // Constructor
        public RatingService(DineOnDBContext context)
        {
            _context = context;
        }
        public void AddRating(int rating, int menuItemId)
        {
            var menuItem = _context.MenuItems.FirstOrDefault(asset => asset.MenuItemId == menuItemId);
            var newEntry = new Rating
            {
                RatingValue = rating,
                MenuItem = menuItem
            };

            _context.Add(newEntry);
            _context.SaveChanges();
        }

        public int GetAverageRating(int menuItemId)
        {
           return Convert.ToInt32(GetMenuItemRating(menuItemId).Average());
        }

        public IEnumerable<Rating> GetAll()
        {
            return _context.Ratings
                .Include(asset => asset.MenuItem);
        }

        public List<int> GetMenuItemRating(int menuItemId)
        {
            return _context.Ratings.Where(asset => asset.MenuItem.MenuItemId == menuItemId).Select(asset => asset.RatingValue).ToList();
        }

        public int GetNumberofRatings(int menuItemId)
        {
            return GetMenuItemRating(menuItemId).Count();
        }


    }
}