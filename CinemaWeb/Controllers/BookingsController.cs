using CinemaLogic.Managers;
using CinemaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Controllers
{
    public class BookingsController : Controller
    {
        private CategoryManager category = new CategoryManager();
        private MovieManager movie = new MovieManager();
        private BookingManager booking = new BookingManager();
        private CategoryModel model = new CategoryModel();
        private MovieModel movModel = new MovieModel();
        private BookingModel bookingModel = new BookingModel();


        public IActionResult Booking(int? id)
        {
            bookingModel.Movies = movie.GetMovies();
            bookingModel.Categories = category.GetCategories();

            if (id.HasValue)
            {
                bookingModel.ActiveCategory = category.GetCategory(id.Value);
                bookingModel.ActiveMovie = movie.OneMovie(id.Value);
                bookingModel.Movies = movie.GetMovByCategory(id.Value);
            }
            return View(bookingModel);
        }

        public IActionResult UserBookings()
        {
            var bookings = booking.UserBookings();

            return View(bookings);
        }

        public IActionResult BookAMovie(int id)
        {
            booking.BookAMovie(id);

            return RedirectToAction(nameof(UserBookings));
        }



        public IActionResult CancelBooking(int id)
        {
            booking.CancelBooking(id);

            return RedirectToAction(nameof(UserBookings));
        }



    }
}
