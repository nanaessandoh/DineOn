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
    public class CommentService : IComment
    {
        // Create DbContext private field  
        private readonly DineOnDBContext _context;
        // Constructor
        public CommentService(DineOnDBContext context)
        {
            _context = context;
        }
        public void AddComment(Comment newComment)
        {
            _context.Add(newComment);
            _context.SaveChanges();
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments
                .Include(asset => asset.MenuItem)
                .Include(asset => asset.Patron);
        }

        public IEnumerable<Comment> GetMenuItemComments(int menuItemId)
        {
            return GetAll()
                .Where(asset => asset.MenuItem.MenuItemId == menuItemId);
        }

        public IEnumerable<Comment> GetPatronComments(int patronId)
        {
            return GetAll()
                .Where(asset => asset.Patron.PatronId == patronId);

        }
    }
}
