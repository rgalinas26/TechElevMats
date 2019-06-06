using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Models
{
    /// <summary>
    /// Represent a store, which has an invenotry of products
    /// </summary>
    public class Store
    {
        /// <summary>
        ///  Internal representation of our inventory, it is a dictionary, whose Key is the product category,
        ///  and whose value is the list of products belonging to that category
        /// </summary>
        private Dictionary<string, List<Product>> inventory;

        /// <summary>
        /// Get the list of categories in our store as an immutable array
        /// </summary>
        public string[] Categories
        {
            get
            {
                List<string> categories = new List<string>();
                foreach (KeyValuePair<string, List<Product>> kvp in this.inventory)
                {
                    categories.Add(kvp.Key);
                }

                // This would also work instead of the above
                //foreach(string cat in this.inventory.Keys)
                //{
                //    categories.Add(cat);
                //}

                return categories.ToArray();
            }
        }


        /// <summary>
        /// Constructor for the store. Loads up the inventory given a product list
        /// </summary>
        /// <param name="productsList">List of products our store carries</param>
        public Store(List<Product> productsList)
        {
            // Initialize a new invenotry dictionary.
            this.inventory = new Dictionary<string, List<Product>>();

            // Loop through the list of products we received, and create keys and values in our dictionary.
            foreach (Product anInventoryProduct in productsList)
            {
                if (this.inventory.ContainsKey(anInventoryProduct.Category))
                {
                    // If the Category already exists as a key in our dictionary, that means that at least one 
                    // product has been added for that category.  Just add this product to that list.
                    this.inventory[anInventoryProduct.Category].Add(anInventoryProduct);
                }
                else  // the dictionary does not yet contain a key for category
                {
                    // If the category does not yet exist as a key, this is the first product we have seen from
                    // that category. Add an entry in the dictionary with the category as a key, and a new empty list
                    // of products as the value.  Then add our current product to that list.
                    this.inventory[anInventoryProduct.Category] = new List<Product>();

                    // This form would also have worked
                    //this.inventory.Add(anInventoryProduct.Category, new List<Product>());

                    this.inventory[anInventoryProduct.Category].Add(anInventoryProduct);
                }
            }
        }

        public Product[] GetProductsForCategory(string categoryToGetProductsFor)
        {
            if (this.inventory.ContainsKey(categoryToGetProductsFor))
            {
                return this.inventory[categoryToGetProductsFor].ToArray();
            }
            return new Product[0];
        }

    }
}
