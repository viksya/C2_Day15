using CinemaLogic.Managers;
using CinemaWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaWeb.Controllers
{
    public class HomeController : Controller
    {
        private CategoryManager category = new CategoryManager();
        private MovieManager movie = new MovieManager();
        CategoryModel model = new CategoryModel();
        IndexModel indexModel = new IndexModel();

        public IActionResult Index(int? id)
        {
            //var movies = movie.GetMovies();
            indexModel.Movies = movie.GetMovies();
            indexModel.Categories = category.GetCategories();
            if (id.HasValue)
            {
                indexModel.ActiveCategory = category.GetCategory(id.Value);

                indexModel.Movies = movie.GetMovByCategory(id.Value);
            }


            return View(indexModel);
        }

        //public IActionResult dropdownCategory(int id)
        //{
        //    CategoryModel model = new CategoryModel();
        //    model.Categories = category.GetDropdCategories();
        //    //if (id.HasValue)
        //    //{
        //    //    model.ActiveCategory = category.GetCategory(id.Value);

        //    //}

        //    return View(model);
        //}

        public IActionResult dropdownCategory(int id)
        {

            indexModel.Categories = category.GetCategories();

                indexModel.ActiveCategory = category.GetCategory(id);

                indexModel.Movies = movie.GetMovByCategory(id);


            return View(indexModel);
        }
    }
}
