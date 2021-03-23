using CinemaLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Models
{
    public class MovieModel
    {
        public List<Movies> Movies { get; set; }

        public List<Bookings> Bookings { get; set; }

        public Movies ActiveMovie { get; set; }

        public List<Auditoriums> Auditoriums { get; set; }

        public Auditoriums Auditorium { get; set; }
    }
}
