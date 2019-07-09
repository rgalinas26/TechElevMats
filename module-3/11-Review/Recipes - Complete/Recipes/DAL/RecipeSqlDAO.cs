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

        /// <summary>
        /// Saves the recipe to the database.
        /// </summary>
        /// <param name="user"></param>
        public int CreateRecipe(Recipe recipe)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //TODO: Finish this query
                    conn.Open();

                    // Start a transaction
                    SqlTransaction transaction = conn.BeginTransaction();

                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO Recipe (Name, CreatedById, Description, Steps, Meal, Cuisine,
                            ImageFile, PrepTime, CookTime, Serves) 
                            VALUES (@Name, @CreatedById, @Description, @Steps, @Meal, @Cuisine,
                            @ImageFile, @PrepTime, @CookTime, @Serves); Select @@Identity;", conn);
                    cmd.Parameters.AddWithValue("@Name", recipe.Name);
                    cmd.Parameters.AddWithValue("@CreatedById", recipe.CreatedById);
                    cmd.Parameters.AddWithValue("@Description", recipe.Description);
                    cmd.Parameters.AddWithValue("@Steps", recipe.Steps);
                    cmd.Parameters.AddWithValue("@Meal", recipe.Meal);
                    cmd.Parameters.AddWithValue("@Cuisine", recipe.Cuisine);
                    cmd.Parameters.AddWithValue("@ImageFile", recipe.ImageFile);
                    cmd.Parameters.AddWithValue("@PrepTime", recipe.PrepTime);
                    cmd.Parameters.AddWithValue("@CookTime", recipe.CookTime);
                    cmd.Parameters.AddWithValue("@Serves", recipe.Serves);
                    cmd.Transaction = transaction;

                    int recipeId = Convert.ToInt32(cmd.ExecuteScalar());

                    // Loop through each Ingredient and write it also
                    foreach (Ingredient ing in recipe.Ingredients)
                    {
                        SqlCommand ingCmd = new SqlCommand(
                            @"Insert Into Ingredient (RecipeId, Name, Quantity, Unit) 
                            VALUES(@RecipeId, @Name, @Quantity, @Unit);", conn);
                        ingCmd.Parameters.AddWithValue("@RecipeId", recipeId);
                        ingCmd.Parameters.AddWithValue("@Name", ing.Name);
                        ingCmd.Parameters.AddWithValue("@Quantity", ing.Quantity);
                        ingCmd.Parameters.AddWithValue("@Unit", ing.Unit);
                        ingCmd.Transaction = transaction;
                        ingCmd.ExecuteNonQuery();
                    }

                    // commit the transaction
                    transaction.Commit();
                    return recipeId;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets a recipe from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Recipe GetRecipeById(int id)
        {
            Recipe recipe = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //TODO: Finish this query
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        @"SELECT * FROM Recipe WHERE Id = @Id;
                           Select * from Ingredient WHERE RecipeId = @Id", 
                        conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        recipe = RowToRecipe(reader);
                    }

                    // Get the ingredients
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            recipe.Ingredients.Add(RowToIngredient(reader));
                        }
                    }
                }

                return recipe;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        // The list of recipes DOES NOT include Ingredients
        public IList<Recipe> GetRecipes(string cuisine)
        {
            List<Recipe> list = new List<Recipe>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    //TODO: Add parameters for filtering
                    conn.Open();
                    string cuisineFilter = $"%{cuisine}%";
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Recipe Where Cuisine like @cuisine", conn);
                    cmd.Parameters.AddWithValue("@cuisine", cuisineFilter);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        list.Add(RowToRecipe(reader));
                    }
                }

                return list;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
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

    }
}
