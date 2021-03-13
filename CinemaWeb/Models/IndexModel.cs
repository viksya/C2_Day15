using CinemaLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Models
{
    public class IndexModel
    {
        public List<Categories> Categories { get; set; }

        public List<Movies> Movies { get; set; }

        public List<Bookings> Bookings { get; set; }

        public Categories ActiveCategory { get; set; }

        public Movies ActiveMovie { get; set; }
    }
}
