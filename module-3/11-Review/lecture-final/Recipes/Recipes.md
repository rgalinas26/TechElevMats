# Recipes
## Features
| Feature | Route | Notes
| --- | --- | --- |
| View a tiled page of recipes | /Home/Index |
| Filter view by meal, by cuisine | /Home/Index?Meal=Dinner&Cuisine=Indian |
| View the details for a recipe | /Home/Detail/id |
| Mark a recipe as a favorite | /Home/Detail/id/Favorite | Must be logged in. Post, re-direct to detail. |
| Add a recipe | /Home/Add | Must be logged in. Multi-page add views |
| Upload an image for the recipe | | Part of the add process |


## Add a recipe
* Multi-page add process
    * Page 1
        * Name, cuisine, meal, image, description
    * Page 2
        * Show ingredient list
        * Add an ingredient
        * Delete an ingredient
    * Page 3
        * Steps
* Use Session to retain in-progress recipe data
    * Clear session after add
    * Allow user to Clear recipe data and start over
## Tables
* Recipe
* Ingredient
* User
* Favorite

# Development Process
1. Create the ASP.NET core MVC web application
2. Create a database project
3. Create the tables and relationships in the DB project
4. Build Model objects for User, Recipe
5. Create the DAO Classes and Interfaces
1. Setup Dependency Injection for DAO objects
1. Implement Home/Index action
    * Get list of recipes
    * Return view(recipes)
1. Implement Home/Index view
    * model Recipes
    * foreach, list recipe
    * add a-href for Detail/id
1. Implement Home/Detail/id action
    * GetById(id)
    * return view(recipe)
1. Implement Home/Detail/id view
    * model Recipe
    * Show fields
1. Setup program to work with Session
    * Startup.cs
    * SaveRecipeInProgress / GetRecipeInProgress
1. Build the Add views and actions
    * Add - 
    * Add2 - 
    * Add3
1. Create the Ingredient Model
1. Update the Recipe DAO to read in and update Ingredients as well as the recipe
