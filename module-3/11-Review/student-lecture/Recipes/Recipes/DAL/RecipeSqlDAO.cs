using Recipes.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.DAL
{
    public class RecipeSqlDAO : IRecipeDAO
    {
        private readonly string connectionString;

        public RecipeSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private Recipe RowToRecipe(SqlDataReader row)
        {
            // TODO: Handle NULL values
            return new Recipe()
            {
                Id = Convert.ToInt32(row["Id"]),
                Name = Convert.ToString(row["Name"]),
                CreatedById = Convert.ToInt32(row["CreatedById"]),
                Description = Convert.ToString(row["Description"]),
                Steps = Convert.ToString(row["Steps"]),
                Meal = Convert.ToString(row["Meal"]),
                Cuisine = Convert.ToString(row["Cuisine"]),
                ImageFile = Convert.ToString(row["ImageFile"]),
                PrepTime = Convert.ToInt32(row["PrepTime"]),
                CookTime = Convert.ToInt32(row["CookTime"]),
                Serves = Convert.ToInt32(row["Serves"]),
            };
        }

        private Ingredient RowToIngredient(SqlDataReader row)
        {
            return new Ingredient()
            {
                Id = Convert.ToInt32(row["Id"]),
                RecipeId = Convert.ToInt32(row["RecipeId"]),
                Name = Convert.ToString(row["Name"]),
                Quantity = Convert.ToDouble(row["Quantity"]),
                Unit = Convert.ToString(row["Unit"]),
            };
        }

        public int CreateRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Recipe GetRecipeById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Recipe> GetRecipes(string cuisine)
        {
            throw new NotImplementedException();
        }
    }
}
