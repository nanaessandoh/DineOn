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
        private readonly IRating _ratingService;

        // Constructor to enable us access IVehicleRentalAsset object
        public MenuController(IMenuItem menuService, IRating ratingService)
        {
            _menuService = menuService;
            _ratingService = ratingService;

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


        public IActionResult Burger()
        {
            var model = new CategoryModel
            {
                CategoryMenuItems = _menuService.GetByCategoryName("Burger"),
            };

            return View(model);
        }

        public IActionResult Dessert()
        {
            var model = new CategoryModel
            {
                CategoryMenuItems = _menuService.GetByCategoryName("Dessert"),
            };

            return View(model);
        }


        public IActionResult Mexican()
        {
            var model = new CategoryModel
            {
                CategoryMenuItems = _menuService.GetByCategoryName("Mexican"),
            };

            return View(model);
        }

        public IActionResult Pizza()
        {
            var model = new CategoryModel
            {
                CategoryMenuItems = _menuService.GetByCategoryName("Pizza"),
            };

            return View(model);
        }

        public IActionResult Starter()
        {
            var model = new CategoryModel
            {
                CategoryMenuItems = _menuService.GetByCategoryName("Starter"),
            };

            return View(model);
        }

        public IActionResult Vegetarian()
        {
            var model = new CategoryModel
            {
                CategoryMenuItems = _menuService.GetByCategoryName("Vegetarian"),
            };

            return View(model);
        }

        public IActionResult Detail(int menuItemId)
        {
            var asset = _menuService.GetById(menuItemId);

            var model = new MenuItemDetailModel  
            {
               MenuItemId = asset.MenuItemId,
               Name = asset.Name,
               Description = asset.Description,
               ImageUrl = asset.ImageUrl,
               Price = asset.Price,
               AverageRating = _ratingService.GetAverageRating(menuItemId),
               NumberOfRatings = _ratingService.GetNumberofRatings(menuItemId)
            };

            return PartialView(model);
        }



        public IActionResult viewDetail()
        {

            return PartialView();
        }

    }
}
