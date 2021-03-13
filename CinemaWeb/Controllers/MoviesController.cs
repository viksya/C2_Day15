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
        CategoryModel model = new CategoryModel();
        MovieModel movModel = new MovieModel();


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




        public IActionResult Movie(int? id)
        {
            movModel.Movies = movie.GetMovies();
            //var movies = movie.OneMovie(id);
            if (id.HasValue)
            {
                movModel.ActiveMovie = movie.OneMovie(id.Value);
                movModel.Movies = movie.GetMovByCategory(id.Value);
            }
            return View(movModel);
        }

        public IActionResult Booking()
        {
            BookingModel model = new BookingModel();
            return View(model);
        }


        public IActionResult BookAMovie(string title)
        {
            movie.BookAMovie(title);

            return RedirectToAction(nameof(Booking));
        }

        public IActionResult CancelBooking(string title)
        {
            movie.CancelBooking(title);

            // send to page
            return RedirectToAction(nameof(Booking));
        }





    }
}
