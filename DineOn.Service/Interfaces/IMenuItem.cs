using DineOn.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service.Interfaces
{
    public interface IMenuItem
    {
        IEnumerable<MenuItem> GetAll();
        IEnumerable<MenuItem> GetAllTopPicks();
        IEnumerable<MenuItem> GetAvailableMenu();
        IEnumerable<MenuItem> GetByCategory(int categoryId);
        MenuItem GetById(int menuItemId);
        void Add(MenuItem newMenuItem);
    
        
    }
}
