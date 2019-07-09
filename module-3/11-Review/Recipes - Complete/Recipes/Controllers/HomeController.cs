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
            string cuisine = GetPreferredCuisine();
            return View(recipeDAO.GetRecipes(cuisine));
        }

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
        public IActionResult Add()
        {
            // Get any recipe in-progress
            Recipe recipe = GetRecipeInProgress();

            return View(recipe);
        }

        [HttpPost]
        public IActionResult Add(Recipe recipe)
        {
            // Get the current values from Session
            Recipe recipeInProgress = GetRecipeInProgress();

            // TODO: How to Validate?

            // Apply values from this view to the one in the cart
            recipeInProgress.Name = recipe.Name;
            // TODO: Get the user id and put it here
            recipeInProgress.CreatedById = 1;


            recipeInProgress.Description = recipe.Description;
            recipeInProgress.ImageFile = recipe.ImageFile;
            recipeInProgress.Meal = recipe.Meal;
            recipeInProgress.Cuisine = recipe.Cuisine;
            recipeInProgress.PrepTime = recipe.PrepTime;
            recipeInProgress.CookTime = recipe.CookTime;
            recipeInProgress.Serves = recipe.Serves;

            SaveRecipeInProgress(recipeInProgress);

            // Go to the next view
            return RedirectToAction("Add2", "Home");
        }

        [HttpGet]
        public IActionResult Add2()
        {
            // Get the current values from Session
            Recipe recipe = GetRecipeInProgress();
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Add2(string name, double quantity, string unit)
        {
            // Get the current values from Session
            Recipe recipeInProgress = GetRecipeInProgress();

            // TODO: How to Validate?

            // Add the ingredients from this view to the one in the cart
            recipeInProgress.Ingredients.Add(new Ingredient()
            {
                Name = name,
                Quantity = quantity,
                Unit = unit
            });

            //recipeInProgress.Ingredients.Add(new Ingredient()
            //{
            //    Name = "Test Ingredient 21",
            //    Quantity = 1,
            //    Unit = "tsp"
            //});

            SaveRecipeInProgress(recipeInProgress);

            // Go to the next view
            return View(recipeInProgress);

            return RedirectToAction("Add3", "Home");
        }

        [HttpGet]
        public IActionResult Add3()
        {
            // Get the current values from Session
            Recipe recipe = GetRecipeInProgress();
            return View(recipe);
        }

        [HttpPost]
        public IActionResult Add3(Recipe recipe)
        {
            // Get the current values from Session
            Recipe recipeInProgress = GetRecipeInProgress();

            // TODO: How to Validate?

            // Apply values from this view to the one in the cart
            recipeInProgress.Steps = recipe.Steps;

            // Save the recipe
            int recipeId = recipeDAO.CreateRecipe(recipeInProgress);

            // Clear the Session recipe
            ClearRecipeInProgress();

            // Go to the next view
            return RedirectToAction("AddConfirmation", "Home", new { id = recipeId });
        }

        [HttpGet]
        public IActionResult AddConfirmation(int id)
        {
            // Get the recipe given the new id
            Recipe recipe = recipeDAO.GetRecipeById(id);
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

        private void SaveRecipeInProgress(Recipe recipe)
        {
            // Convert the Recipe object to a string using the JSON library
            string json = JsonConvert.SerializeObject(recipe);

            // Put the string into session under the key="RecipeInProgress"
            HttpContext.Session.SetString("RecipeInProgress", json);
        }

        private void ClearRecipeInProgress()
        {
            // Put the string into session under the key="RecipeInProgress"
            HttpContext.Session.Remove("RecipeInProgress");
        }

        private Recipe GetRecipeInProgress()
        {
            Recipe recipe = null;

            // Get the serialized json string from the session, key="Cart"
            string json = HttpContext.Session.GetString("RecipeInProgress");

            if (json == null)
            {
                recipe = new Recipe();
            }
            else
            {
                // De-serialize the json string into a SC object
                recipe = (Recipe)JsonConvert.DeserializeObject<Recipe>(json);
            }
            return recipe;
        }

        private string GetPreferredCuisine()
        {
            return HttpContext.Session.GetString("PreferredCuisine") ?? "";
        }

        private void SetPreferredCuisine(string cuisine)
        {
            if (cuisine == null || cuisine.Trim().Length == 0)
            {
                ClearPreferredCuisine();
            }
            else
            {
                HttpContext.Session.SetString("PreferredCuisine", cuisine);
            }
        }

        private void ClearPreferredCuisine()
        {
            HttpContext.Session.Remove("PreferredCuisine");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
