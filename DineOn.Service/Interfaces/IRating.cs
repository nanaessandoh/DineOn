using DineOn.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service.Interfaces
{
    public interface IRating
    {
        IEnumerable<Rating> GetAll();
        List<int> GetMenuItemRating(int menuItemId);
        void AddRating(int rating, int menuItemId);
        int GetNumberofRatings(int menuItemId);
        int GetAverageRating(int menuItemId);
    }
}
