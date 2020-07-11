using DineOn.Data;
using DineOn.Data.Models;
using DineOn.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service
{
    public class CategoryService : ICategory
    {
        // Create DbContext private field  
        private readonly DineOnDBContext _context;
        // Constructor
        public CategoryService(DineOnDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }
    }
}
