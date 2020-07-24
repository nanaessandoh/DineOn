using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DineOn.Web.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace DineOn.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("cartId")))
            {
                HttpContext.Session.SetString("cartId", Guid.NewGuid().ToString());
            }
            ViewData["Title"] = "Homepage";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("cartId")))
            {
                HttpContext.Session.SetString("cartId", Guid.NewGuid().ToString());
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
