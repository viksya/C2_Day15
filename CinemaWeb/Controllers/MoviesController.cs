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
        private MovieManager movie = new MovieManager();



        public IActionResult Category(int id)
        {
            var data = category.GetCategories();
            return View(data);
        }

        public IActionResult Booking()
        {
            var booking = movie.UserBookings(); 

            return View(booking);
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
