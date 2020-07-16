using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DineOn.Service;
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
            ViewData["Title"] = "Full Menu";
            return View();
        }


        public IActionResult Burger()
        {
            
           ViewData["Title"] = "Burgers";  
            return View();
        }

        public IActionResult Dessert()
        {
            ViewData["Title"] = "Desserts";
            return View(); ;
        }


        public IActionResult Mexican()
        {
            ViewData["Title"] = "Mexican";
            return View();
        }

        public IActionResult Pizza()
        {
            ViewData["Title"] = "Pizzas";
            return View();
        }

        public IActionResult Starter()
        {
            ViewData["Title"] = "Starters";
            return View();
        }

        public IActionResult Vegetarian()
        {
            ViewData["Title"] = "Vegetarian";
            return View();
        }




    }
}
