using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionCart.Web.DAL;
using SessionCart.Web.Models;
using Newtonsoft.Json;

namespace SessionCart.Web.Controllers
{
    public class StoreController : Controller
    {
        /* Steps
           1. (StoreController)    Create Index Action for store/index
           2. (Index View)         Create Index View for store/index
           TEST
           3. (Startup.cs)         Configure DI container to inject IProductDAL > FakeProductDAL
           4. (StoreController)    Enable constructor injection for IProductDAL
           5. (StoreController)    Update Index Action to pass products
           6. (Index View)         Display Products
           TEST
           7. (Index View)         Add Form Tag w/ AddToCart button > POST to store/index
                                   Pass Product Id in Form
           8. (StoreController)    Create POST Index Action for store/index, accept product id & 
                                   redirect to store/viewcart            
           9. (StoreController)    Create ViewCart action for store/viewcart
           10.(ViewCart View)      Display empty View Cart View
           TEST
           11.(StoreController)    POST store/index: retrieve product and add to active
                                   shopping cart
           12.(ShoppingCart)       Create Shopping Cart class to add Product & Quantity
           13.(StoreController)    Guarantee ShoppingCart is in session, create if not
           14.(StoreController)    POST store/index: Update shopping cart with new product
           15.(StoreController)    GET store/viewcart: Retrieve shoping cart from session
           16.(ViewCart View)      Bind go ShoppingCart and disply each product in it
       */
        private IProductDAO productDAO;
        public StoreController(IProductDAO productDAO)
        {
            this.productDAO = productDAO;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IList<Product> products = productDAO.GetProducts();
            return View(products);
        }

        [HttpPost]
        public IActionResult Index(Product product)
        {
            product = productDAO.GetProduct(product.Id);

            // Get the shopping cart from session
            ShoppingCart cart = GetShoppingCart();

            // Add this product to the cart
            cart.AddToCart(product, 1);

            // Save the updated cart to session
            SaveShoppingCart(cart);

            return RedirectToAction("ViewCart");
        }

        private void SaveShoppingCart(ShoppingCart cart)
        {
            // Convert the SC object to a string using the JSON library
            string jsonCart = JsonConvert.SerializeObject(cart);

            // Put the string into session under the key="Cart"
            HttpContext.Session.SetString("Cart", jsonCart);
        }

        private ShoppingCart GetShoppingCart()
        {
            ShoppingCart cart = null;

            // Get the serialized json string from the session, key="Cart"
            string jsonCart = HttpContext.Session.GetString("Cart");

            if (jsonCart == null)
            {
                cart = new ShoppingCart();
            }
            else
            {
                // De-serialize the json string into a SC object
                cart = (ShoppingCart)JsonConvert.DeserializeObject<ShoppingCart>(jsonCart);
            }
            return cart;
        }

        [HttpGet]
        public IActionResult ViewCart()
        {
            // Get the shopping cart from session
            ShoppingCart cart = GetShoppingCart();

            // Pass the cart to the view for display
            return View(cart);
        }



    }
}