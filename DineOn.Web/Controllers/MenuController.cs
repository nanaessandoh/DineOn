using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DineOn.Service.Interfaces;
using DineOn.Web.Models.Menu;
using Microsoft.AspNetCore.Mvc;

namespace DineOn.Web.Controllers
{
    public class MenuController : Controller
    {

        private readonly IMenuItem _menuService;

        // Constructor to enable us access IVehicleRentalAsset object
        public MenuController(IMenuItem menuService)
        {
            _menuService = menuService;

        }


        public IActionResult Index()
        {
            var model = new MenuIndexModel
            {
                Burgers = _menuService.GetByCategoryName("Burger"),
                Desserts = _menuService.GetByCategoryName("Dessert"),
                Mexican =  _menuService.GetByCategoryName("Mexican"),
                Pizzas = _menuService.GetByCategoryName("Pizza"),
                Starters = _menuService.GetByCategoryName("Starter"),
                Vegetarian = _menuService.GetByCategoryName("Vegetarian")
            };

            return View(model);
        }
    }
}
