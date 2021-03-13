using CinemaLogic.Managers;
using CinemaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Controllers
{
    public class BookingController : Controller
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


        public IActionResult BookAMovie(string title)
        {
            movie.BookAMovie(title);
            //return RedirectToAction(nameof(Booking));
            return View(bookingModel);
        }

        //public IActionResult UserBookings()
        //{
        //    //bookingModel.ActiveBooking.Id= movModel.ActiveMovie.Id();
        //    return View(bookingModel);
        //}

        //public IActionResult CancelBooking(string title)
        //{
        //    //movie.CancelBooking(title);

        //    // send to page
        //    return RedirectToAction(nameof(Booking));
        //}









    }
}
