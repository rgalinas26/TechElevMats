using Market.Models;
using ReviewApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Views
{
    public class CategoriesMenu : CLIMenu
    {
        public CategoriesMenu(Store storeReference) : base(storeReference)
        {
            this.Title = "*** Browse Categories ***";

            string[] cats = this.MyStore.Categories;
            int categoryNumber = 1;
            foreach(string theCategory in cats)
            {
                this.menuOptions.Add(categoryNumber.ToString(), theCategory);
                categoryNumber++;
            }
            this.menuOptions.Add("Q", "Quit");

        }
        protected override bool ExecuteSelection(string choice)
        {
            // Get the category that the user selected from the menu
            int categoryIndex = int.Parse(choice) - 1;
            string categoryToDisplay = this.MyStore.Categories[categoryIndex];

            // Launch the products menu
            ProductsMenu prodMenu = new ProductsMenu(this.MyStore, categoryToDisplay);
            prodMenu.Run();

            return true;
        }
    }
}
