using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DineOn.Web.Models;
using Microsoft.AspNetCore.Mvc;
using DineOn.Service.Interfaces;
using Microsoft.AspNetCore.Http;

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
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("cartId")))
            {
                HttpContext.Session.SetString("cartId", Guid.NewGuid().ToString());
            }
            ViewData["Title"] = "Full Menu";
            return View();
        }


        public IActionResult Burger()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("cartId")))
            {
                HttpContext.Session.SetString("cartId", Guid.NewGuid().ToString());
            }
            ViewData["Title"] = "Burgers";
            return View();
        }

        public IActionResult Dessert()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("cartId")))
            {
                HttpContext.Session.SetString("cartId", Guid.NewGuid().ToString());
            }
            ViewData["Title"] = "Dessert";
            return View();
        }


        public IActionResult Mexican()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("cartId")))
            {
                HttpContext.Session.SetString("cartId", Guid.NewGuid().ToString());
            }
            ViewData["Title"] = "Mexican";
            return View();
        }

        public IActionResult Pizza()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("cartId")))
            {
                HttpContext.Session.SetString("cartId", Guid.NewGuid().ToString());
            }
            ViewData["Title"] = "Pizza";
            return View();
        }

        public IActionResult Starter()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("cartId")))
            {
                HttpContext.Session.SetString("cartId", Guid.NewGuid().ToString());
            }
            ViewData["Title"] = "Starter";
            return View();
        }

        public IActionResult Vegetarian()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("cartId")))
            {
                HttpContext.Session.SetString("cartId", Guid.NewGuid().ToString());
            }
            ViewData["Title"] = "Vegetarian";
            return View();
        }
    }
}
