using CinemaLogic.Managers;
using CinemaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Controllers
{
    public class HomeController : Controller
    {
        private CategoryManager category = new CategoryManager();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Category()
        {
            var data = category.GetCategories();
            return View(data);
        }

        public IActionResult Booking()
        {
            return View();
        }
    }
}
