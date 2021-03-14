﻿using CinemaLogic.Managers;
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
        private IndexModel indexModel = new IndexModel();
        private MovieModel movModel = new MovieModel();

        public IActionResult Index(int? id)
        {
            indexModel.Movies = movie.GetMovies();
            indexModel.Categories = category.GetCategories();
            if (id.HasValue)
            {
                indexModel.ActiveMovie = movie.OneMovie(id.Value);
                movie.OneMovie(id.Value);
                return RedirectToAction("Movie", "Movies");
            }
            return View(indexModel);
        }

        public IActionResult HomepageMovie(int id)
        {

            movie.OneMovie(id);
            return RedirectToAction("Movie", "Movies");

            //return View(movModel);
            //return RedirectToAction("Movie", "Movies");
        }



        //public IActionResult dropdownCategory(int id)
        //{
        //    indexModel.Categories = category.GetCategories();
        //    indexModel.ActiveCategory = category.GetCategory(id);
        //    indexModel.Movies = movie.GetMovByCategory(id);
        //    return View(indexModel);
        //}
    }
}
