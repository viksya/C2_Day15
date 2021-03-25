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
        private IndexModel indexModel = new IndexModel();
        private MovieModel movModel = new MovieModel();

        public IActionResult Index(int? id)
        {
            indexModel.Movies = movie.GetMovies();
            indexModel.Categories = category.GetCategories();
            
            if (id.HasValue)
            {
                movie.OneMovie(id.Value);
                movModel.ActiveMovie = movie.OneMovie(id.Value);
                return RedirectToAction("Movie", "Movies", new { id });
            }
            return View(indexModel);
        }
    }
}
