using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DineOn.Web.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("cartId")))
            {
                HttpContext.Session.SetString("cartId", Guid.NewGuid().ToString());
            }
            ViewData["Title"] = "OrderCart";
            return View();
        }

        public IActionResult Checkout()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("cartId")))
            {
                HttpContext.Session.SetString("cartId", Guid.NewGuid().ToString());
            }
            ViewData["Title"] = "Checkout";
            return View();
        }

        public IActionResult Success()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("cartId")))
            {
                HttpContext.Session.SetString("cartId", Guid.NewGuid().ToString());
            }
            ViewData["Title"] = "Checkout";
            return View();
        }
    }
}
