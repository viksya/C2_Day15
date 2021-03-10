using CinemaLogic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemaLogic.Managers
{
    public class CategoryManager
    {
        public CategoryManager()
        {
                
        }
        public List<Categories> GetCategories()
        {
            using (var db = new CinemaDb())
            {
                return db.Categories.OrderBy(t => t.Title).ToList();
            }
        }






    }
}