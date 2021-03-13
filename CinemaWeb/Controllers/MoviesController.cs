using CinemaLogic.Managers;
using CinemaWeb.Models;
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
        private MovieManager movie = new MovieManager();
        private CategoryModel model = new CategoryModel();
        private MovieModel movModel = new MovieModel();


        public IActionResult Category(int? id)
        {
            
            model.Categories = category.GetCategories();

            if (id.HasValue)
            {
                model.ActiveCategory = category.GetCategory(id.Value);
                model.Movies = movie.GetMovByCategory(id.Value);
            }
            else
            {
                model.Movies = movie.GetMovies();
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Movie(int? id)
        {
            movModel.Movies = movie.GetMovies();
            //var movies = movie.OneMovie(id);
            if (id.HasValue)
            {
                movModel.ActiveMovie = movie.OneMovie(id.Value);
                //movModel.Movies = movie.GetMovByCategory(id.Value);
            }
            return View(movModel);
        }
        //[HttpPost]
        //public IActionResult Movie()
        //{

        //    return RedirectToAction("Booking", "Booking");
        //}

    }
}
