using DineOn.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DineOn.Service.Interfaces
{
    public interface IMenuItem
    {
        IEnumerable<MenuItem> GetEntireMenu();
        IEnumerable<MenuItem> GetBurgers();
        IEnumerable<MenuItem> GetDesserts();
        IEnumerable<MenuItem> GetMexican();
        IEnumerable<MenuItem> GetPizzas();
        IEnumerable<MenuItem> GetStarters();
        IEnumerable<MenuItem> GetVegetarian();
        MenuItem GetMenuItem(int menuItemId);
        void AddRating(int menuItemId, int rating);
        int GetAverageRating(int menuItemId);
        int GetNumberOfRatings(int menuItemId);


    }
}
