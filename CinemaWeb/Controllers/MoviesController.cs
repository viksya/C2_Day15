using CinemaLogic.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Controllers
{
    public class MoviesController : Controller
    {
        private CategoryManager category = new CategoryManager();
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
