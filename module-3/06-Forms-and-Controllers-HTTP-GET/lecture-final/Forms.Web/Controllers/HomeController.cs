using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forms.Web.Models;
using Forms.Web.DAL;

namespace Forms.Web.Controllers
{
    public class HomeController : Controller
    {        
        /// <summary>
        /// Represents an index action.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }   
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // TODO 01: Create a controller to be used to search for a city (CityController)
        // TODO 02: Write the SearchResults action (country code, district) to do the work of searching for a city. 
        //          We should be able to run the search using the browser's address bar
        // TODO 03: Create a Search Action and View, which presents the user with a search form (country code, district) 
        //          (pure HTML - GET). Action=searchresults
        // TODO 04a:Run the form and see what is sent by the browser (using browser dev tools).
        //          We should get search results.
        // TODO 04b:DEMO: Change the form to POST and compare the payloads.  Change back to GET for today.
        // TODO 05: Model Binding: Create a CitySearchVM model object to hold all the parameters
        // TODO 06: Use asp-helper tags to re-write the form.
        // TODO 07: If time allows, re-write the actions to show the form AND display the results
        // TODO 08: If time allows, add a SelectList to the view-model for country codes
        // TODO 09: If time allows, generate Select List from the DAO

    }
}
