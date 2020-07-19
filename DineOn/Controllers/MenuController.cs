using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DineOn.Web.Models;
using Microsoft.AspNetCore.Mvc;
using DineOn.Service.Interfaces;

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
            ViewData["Title"] = "Dessert";
            return View();
        }


        public IActionResult Mexican()
        {
            ViewData["Title"] = "Mexican";
            return View();
        }

        public IActionResult Pizza()
        {
            ViewData["Title"] = "Pizza";
            return View();
        }

        public IActionResult Starter()
        {
            ViewData["Title"] = "Starter";
            return View();
        }

        public IActionResult Vegetarian()
        {
            ViewData["Title"] = "Vegetarian";
            return View();
        }
    }
}
