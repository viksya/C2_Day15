using CinemaLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Models
{
    public class BookingModel
    {
        public List<Categories> Categories { get; set; }

        public List<Movies> Movies { get; set; }

        public List<Bookings> Bookings { get; set; }

        public List<SeatTypes> SeatTypes { get; set; }

        public List<Auditoriums> Auditoriums { get; set; }

        public Categories ActiveCategory { get; set; }

        public Movies ActiveMovie { get; set; }

        public Bookings ActiveBooking { get; set; }
        public Auditoriums Auditorium { get; set; }
        public SeatTypes ChosenSeat { get; set; }


    }
}
