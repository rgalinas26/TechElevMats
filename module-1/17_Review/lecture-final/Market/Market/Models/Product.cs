using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Models
{
    /// <summary>
    /// Represents any product that can be in our store inventory
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Name of the product
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Category of the product, such as Fruit or Vegetable
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Constructor to fully populate all the properties of the product
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="price"></param>
        /// <param name="category"></param>
        public Product(string productName, decimal price, string category)
        {
            this.ProductName = productName;
            this.Price = price;
            this.Category = category;
        }
    }
}
