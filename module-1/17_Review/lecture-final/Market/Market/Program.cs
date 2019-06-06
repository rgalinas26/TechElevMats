using Market.Models;
using ReviewApp.Views;
using System;
using System.Collections.Generic;

namespace Market
{
    class Program
    {
        static void Main(string[] args)
        {
            // For now, create a dummy product list in memory. Later we will add loading from a file, and this 
            // product list will be removed from here.
            List<Product> productsList = new List<Product>()
            {
                new Product("Apples", 6.99M, "Fruit"),
                        new Product("Bananas", 1.99M, "Fruit"),
                        new Product("Blueberries", 4.99M, "Fruit"),
                        new Product("Broccoli", 2.50M, "Vegetables"),
                        new Product("Cauliflower", 5.00M, "Vegetables"),
                        new Product("Corn", 6.00M, "Vegetables"),
                        new Product("Eggs", 4.99M, "Dairy"),
                        new Product("Cheese", 12.00M, "Dairy"),
            };

            // Create an instance of a store, and load up its inventory from the product list
            Store store = new Store(productsList);

            // Create an instance of the main menu class, which runs the interaction with the user.
            MainMenu menu = new MainMenu(store);

            // Run() starts the menu's interaction with the user. When Run() finishes, it means the user has typed Q,
            // and we should exit the program.
            menu.Run();
        }
    }
}
