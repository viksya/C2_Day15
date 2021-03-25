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
        private UserManager user = new UserManager();
        private MovieModel movModel = new MovieModel();
        private BookingModel bookingModel = new BookingModel();


        public IActionResult Booking(int? id) 
        {
            bookingModel.Bookings = booking.UserBookings();
            bookingModel.SeatTypes = booking.GetSeatTypes();

            if (id.HasValue)
            {
                bookingModel.ActiveBooking = booking.CurrentBooking(id.Value);
            }
                return View(bookingModel);
        }

        public IActionResult SeatType(int? id)
        {
            bookingModel.SeatTypes = booking.GetSeatTypes();

            if (id.HasValue)
            {
                bookingModel.ChosenSeat = booking.GetSeatType(id.Value);
                //model.Movies = movie.GetMovByCategory(id.Value);
            }

            return View(bookingModel);
        }

        public IActionResult CancelBooking(int id)
        {
            booking.CancelBooking(id);

            return RedirectToAction(nameof(Booking));
        }
    }
}
