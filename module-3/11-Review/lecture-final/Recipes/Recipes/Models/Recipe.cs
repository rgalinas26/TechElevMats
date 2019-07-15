using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedById { get; set; }
        public string Description { get; set; }
        public string Steps { get; set; }
        public string Meal { get; set; }
        public string Cuisine { get; set; }
        public string ImageFile { get; set; }
        public int PrepTime { get; set; }
        public int CookTime { get; set; }
        public int Serves { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public Recipe()
        {
            this.Ingredients = new List<Ingredient>();
        }
    }
}
