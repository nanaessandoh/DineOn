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
        IEnumerable<MenuItem> GetByCategoryName(string categoryName);
        MenuItem GetById(int menuItemId);
        void Add(MenuItem newMenuItem);
    
        
    }
}
