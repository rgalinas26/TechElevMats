using Market.Models;
using ReviewApp.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Views
{
    public class ProductsMenu : CLIMenu
    {
        private string category;
        public ProductsMenu(Store store, string categoryToDisplay) : base(store)
        {
            this.category = categoryToDisplay;

            this.Title = $"*** Products in Category {this.category} ***";
            Product[] productsInThisCategory = this.MyStore.GetProductsForCategory(this.category);
            int productNumber = 1;
            foreach(Product theProduct in productsInThisCategory)
            {
                this.menuOptions.Add(productNumber.ToString(), $"{theProduct.ProductName,-15} {theProduct.Price,7:C}");
                productNumber++;
            }
            this.menuOptions.Add("Q", "Quit");
        }

        protected override bool ExecuteSelection(string choice)
        {
            throw new NotImplementedException();
        }
    }
}
