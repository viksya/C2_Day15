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

        public IActionResult Index(int? id)
        {
            //var movies = movie.GetMovies();
            CategoryModel model = new CategoryModel();
            model.Movies = movie.GetMovies();
            if (id.HasValue)
            {
                model.ActiveCategory = category.GetCategory(id.Value);

                model.Movies = movie.GetMovByCategory(id.Value);
            }


            return View(model);
        }

        public IActionResult dropdownCategory(int? id)
        {
            CategoryModel model = new CategoryModel();
            model.Categories = category.GetCategories();
            if (id.HasValue)
            {
                model.ActiveCategory = category.GetCategory(id.Value);

            }

            return View(model);
        }
    }
}
