using DineOn.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service.Interfaces
{
    public interface IComment
    {
        IEnumerable<Comment> GetAll();
        IEnumerable<Comment> GetMenuItemComments(int menuItemId);
        IEnumerable<Comment> GetPatronComments(int patronId);
        void AddComment(Comment newComment);
    }
}
