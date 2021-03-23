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
        private MovieManager movie = new MovieManager();
        private BookingManager booking = new BookingManager();
        private MovieModel movModel = new MovieModel();
        private BookingModel bookingModel = new BookingModel();


        public IActionResult Booking(int? id) 
        {
            bookingModel.Bookings = booking.UserBookings();

            if (id.HasValue)
            {
                bookingModel.ActiveBooking = booking.CurrentBooking(id.Value);
            }

            return View(bookingModel);
        }

        public IActionResult CancelBooking(int id)
        {
            booking.CancelBooking(id);

            return RedirectToAction(nameof(Booking));
        }

        //public IActionResult LogIn()
        //{
        //    return RedirectToAction("Login", "UserController");
        //}
        //public IActionResult Register()
        //{
        //    return RedirectToAction("Register", "UserController");
        //}
    }
}
