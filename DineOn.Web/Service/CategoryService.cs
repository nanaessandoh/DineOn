using DineOn.Web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;

namespace DineOn.Service
{
    public class CategoryService
    {
        // Create DbContext private field  
        private readonly DineOnDBContext _context;
        // Constructor
        public CategoryService(DineOnDBContext context)
        {
            _context = context;
        }

        public void Add(Category newCategory)
        {
            _context.Add(newCategory);
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }


        public string GetMenuItemCategoryName(int categoryId)
        {
            return _context.Categories
                .FirstOrDefault(asset => asset.CategoryId == categoryId).Name;
        }

    }
}
