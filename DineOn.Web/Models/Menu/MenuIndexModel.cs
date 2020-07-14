using DineOn.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DineOn.Web.Models.Menu
{
    public class MenuIndexModel
    {
        public IEnumerable<MenuItem> Starters;
        public IEnumerable<MenuItem> Burgers;
        public IEnumerable<MenuItem> Mexican;
        public IEnumerable<MenuItem> Pizzas;
        public IEnumerable<MenuItem> Vegetarian;
        public IEnumerable<MenuItem> Desserts;
    }
}
