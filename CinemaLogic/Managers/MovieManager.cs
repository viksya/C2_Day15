using CinemaLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaLogic.Managers
{
    public class MovieManager
    {
        public List<Movies> GetMovies(int count = 6)
        {
            using (var db = new CinemaDb())
            {
                return db.Movies.OrderByDescending(a => a.AvailableTime).Take(count).ToList();
            }
        }
    }
}