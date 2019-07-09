using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Recipes.DAL;
using Recipes.Models;

namespace Recipes.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeDAO recipeDAO = null;
        public HomeController(IRecipeDAO recipeDAO)
        {
            this.recipeDAO = recipeDAO;
        }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
