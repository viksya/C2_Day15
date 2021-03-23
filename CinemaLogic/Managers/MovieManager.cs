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

        public List<Movies> GetMovies()
        {
            using (var db = new CinemaDb())
            {
                return db.Movies.OrderBy(c => c.Title).ToList();
            }
        }

        public List<Movies> GetMovByCategory(int catId)
        {
            using (var db = new CinemaDb())
            {
                return db.Movies
                    .Where(m => m.MovieId == catId)
                    .OrderByDescending(m => m.AvailableTime)
                    .ToList();
            }
        }

        public Movies OneMovie(int id)
        {
            using (var db = new CinemaDb())
            {
                return db.Movies.FirstOrDefault(m => m.Id == id);
            }
        }

        public Movies BookAMovie(int id)
        {
            using (var db = new CinemaDb())
            {
                var movie = db.Movies.FirstOrDefault(m => m.Id == id);

                if (movie != null)
                {
                    db.Bookings.Add(new Bookings()
                    {
                        MovieId = movie.Id,
                        Title = movie.Title,
                        Pic = movie.Pic,
                        Description = movie.Description,
                        SelectedTime = movie.AvailableTime,
                        Auditorium = movie.AuditoriumId,

                        if (HttpContext.Session.IsSignedIn())
                    {
                        
                    }
                    });

                    db.SaveChanges();

                    return movie;
                }
            }
            return null;
        }
    }
}