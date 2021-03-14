using CinemaLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaLogic.Managers
{
    public class BookingManager
    {
        public BookingManager()
        {

        }

        public List<Bookings> UserBookings()
        {
            using (var db = new CinemaDb())
            {
                return db.Bookings.OrderBy(b => b.SelectedTime).ToList();
            }
        }



        public Bookings CancelBooking(int id)
        {
            using (var db = new CinemaDb())
            {
                var currentBooking = db.Bookings.FirstOrDefault(b => b.Id == id);
                if (currentBooking != null)
                {
                    db.Bookings.Remove(currentBooking);

                    db.SaveChanges();

                    return currentBooking;
                }
            }

            return null;
        }


    }
}
