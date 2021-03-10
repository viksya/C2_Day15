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
        private MovieManager movie = new MovieManager();

        public IActionResult Index()
        {
            var movies = movie.GetMovies();

            return View(movies);
        }

        
    }
}
