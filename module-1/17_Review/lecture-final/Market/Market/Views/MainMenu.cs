using Market.Models;
using Market.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReviewApp.Views
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class MainMenu : CLIMenu
    {
        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public MainMenu(Store storeReference) : base(storeReference)
        {
            this.Title = "*** Main Menu ***";
            this.menuOptions.Add("1", "Shop Categories");
            this.menuOptions.Add("2", "Show Cart");
            this.menuOptions.Add("3", "Print a Receipt and Checkout");
            this.menuOptions.Add("Q", "Quit");
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            switch (choice)
            {
                case "1":
                    // Show the categories menu
                    CategoriesMenu menu = new CategoriesMenu(this.MyStore);
                    menu.Run();
                    return true;
                case "2":
                    int someNumber = GetInteger("Please enter a whole number:");
                    Console.WriteLine($"You entered {someNumber}.");
                    Pause("");
                    return true;
                case "3":
                    const string fileName = @"data\receipt.txt";

                    Pause($"Your receipt is available at {fileName}. (not really!)");
                    return true;
            }
            return true;
        }

    }
}
