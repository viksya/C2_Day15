using CinemaLogic.Managers;
using System;

namespace CinemaConsoleNew
{
    class Program
    {
        private static CategoryManager category = new CategoryManager();
        private static MovieManager movie = new MovieManager();

        static void Main(string[] args)
        {
            Console.WriteLine("Categories: ");
            category.GetCategories().ForEach(c =>
            {
                Console.WriteLine(c.Title);
            });

            Console.WriteLine("Movies: ");
            movie.GetMovies().ForEach(m =>
            {
                Console.WriteLine(m.Title);
            });
        }
    }
}