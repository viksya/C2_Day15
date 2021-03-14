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
        private BookingManager booking = new BookingManager();
        private CategoryModel model = new CategoryModel();
        private MovieModel movModel = new MovieModel();
        private BookingModel bookingModel = new BookingModel();

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

            if (id.HasValue)
            {
                movModel.ActiveMovie = movie.OneMovie(id.Value);
            }
            return View(movModel);
        }





        public IActionResult BookAMovie(int? id)
        {
            movModel.Movies = movie.GetMovies();

            if (id.HasValue)
            {
                bookingModel.ActiveMovie = movie.BookAMovie(id.Value);
            }

            //movie.BookAMovie(id);
            return RedirectToAction("Booking", "Bookings");
        }


    }
}
