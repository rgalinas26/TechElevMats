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
        private const string CUISINE_KEY = "PreferredCuisine";
        private IRecipeDAO recipeDAO = null;
        public HomeController(IRecipeDAO recipeDAO)
        {
            this.recipeDAO = recipeDAO;
        }

        public IActionResult Index()
        {
            IList<Recipe> recipes = recipeDAO.GetRecipes(GetPreferredCuisine());
            return View(recipes);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            Recipe recipe = recipeDAO.GetRecipeById(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        [HttpGet]
        public IActionResult Preferences()
        {
            Preferences pref = new Preferences()
            {
                Cuisine = GetPreferredCuisine()
            };

            return View(pref);
        }

        [HttpPost]
        public IActionResult Preferences(Preferences pref)
        {
            SetPreferredCuisine(pref.Cuisine);
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Retrieve the preference from Session
        private string GetPreferredCuisine()
        {
            return HttpContext.Session.GetString(CUISINE_KEY) ?? "";
        }

        // Store the preference in Session
        private void SetPreferredCuisine(string cuisine)
        {
            if (cuisine == null)
            {
                ClearPreferredCuisine();
            }
            else
            {
                HttpContext.Session.SetString(CUISINE_KEY, cuisine);
            }
        }

        // Clear the preference from session
        private void ClearPreferredCuisine()
        {
            HttpContext.Session.Remove(CUISINE_KEY);
        }
    }
}
