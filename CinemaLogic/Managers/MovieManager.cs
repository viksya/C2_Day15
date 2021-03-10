using CinemaLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaLogic.Managers
{
    public class MovieManager
    {
        public MovieManager()
        {
                
        }
        public List<Movies> GetMovies(int count = 6)
        {
            using (var db = new CinemaDb())
            {
                return db.Movies.OrderByDescending(a => a.AvailableTime).Take(count).ToList();
            }
        }

        public Movies BookAMovie(string title)
        {
            using (var db = new CinemaDb())
            {
                var movie = db.Movies.FirstOrDefault(m => m.Title.ToLower() == title.ToLower());

                if (movie != null)
                {
                    db.Bookings.Add(new Bookings()
                    {
                        MovieId = movie.MovieId,
                        Title = movie.Title,
                        SelectedTime = movie.AvailableTime,
                    });

                    db.SaveChanges();

                    return movie;
                }
            }
            return null;
        }



        public List<Bookings> UserBookings()
        {
            using (var db = new CinemaDb())
            {
                return db.Bookings.OrderBy(b => b.SelectedTime).ToList();
            }
        }


        public Bookings CancelBooking(string title)
        {
            using (var db = new CinemaDb())
            {
                var currentBooking = db.Bookings.FirstOrDefault(b => b.Title.ToLower() == title.ToLower());
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