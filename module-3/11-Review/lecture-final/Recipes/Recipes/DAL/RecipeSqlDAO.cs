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
            Recipe recipe = null;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string sql = @"Select * from Recipe Where Id = @id;
                                    Select * from Ingredient where RecipeId = @id;";
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        recipe = RowToRecipe(reader);
                    }

                    // Now get the ingredients result set
                    if (reader.NextResult())
                    {
                        while(reader.Read())
                        {
                            recipe.Ingredients.Add(RowToIngredient(reader));
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // TODO: Log error here
                throw ex;
            }


            return recipe;
        }

        public IList<Recipe> GetRecipes(string cuisine)
        {
            List<Recipe> list = new List<Recipe>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string cuisineFilter = $"%{cuisine}%";
                    string sql = "Select * from Recipe Where Cuisine like @cuisine;";

                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@cuisine", cuisineFilter);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        list.Add(RowToRecipe(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                // TODO: Log error here
                throw ex;
            }
            return list;
        }
    }
}
