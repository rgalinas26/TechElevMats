using System.Collections.Generic;
using Recipes.Models;

namespace Recipes.DAL
{
    public interface IRecipeDAO
    {
        int CreateRecipe(Recipe recipe);
        Recipe GetRecipeById(int id);
        IList<Recipe> GetRecipes(string cuisine);
    }
}