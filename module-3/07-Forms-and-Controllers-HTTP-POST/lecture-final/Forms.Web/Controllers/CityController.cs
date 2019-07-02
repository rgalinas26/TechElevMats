using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Web.DAL;
using Forms.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forms.Web.Controllers
{
    public class CityController : Controller
    {
        private ICityDAO cityDAO;

        public CityController(ICityDAO cityDAO)
        {
            this.cityDAO = cityDAO;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Search(CitySearchVM vm)
        {
            if (vm.CountryCode != null)
            {
                // Use the dao to get the cities that match the search
                vm.Cities = cityDAO.GetCities(vm.CountryCode, vm.District);
            }

            // TODO 01c: Call the GetCountries private method, which Populates the country list on the view model
            vm.CountryList = GetCountries();

            // Pass the results into the SearchResults view for display
            return View(vm);
        }

        // TODO 01b: Create a method which creates a list of SelectListItems for a dropdown
        private SelectList GetCountries()
        {
            // Populate the country search list
            IList<Country> countries = cityDAO.GetCountries();
            SelectList countryList = new SelectList(countries, "Code", "Name");
            return countryList;
        }

        // Create an Action to handle the Add City, GET
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(City city)
        {
            // I might put some validation here, but I am lazy

            // Use the dao to add the city
            int newCityId = cityDAO.AddCity(city);

            // Redirect to a confirmation page
            var obj = new { id = newCityId };
            return RedirectToAction("AddConfirmation", obj );
        }

        [HttpGet]
        public IActionResult AddConfirmation(int id)
        {
            City city = cityDAO.GetCityById(id);
            return View(city);
        }


        // TODO 03: Implement the PRG pattern to add a new city
        // TODO 03a: Create an AddCity (GET) method to handle the request and show the form
        // TODO 03b: Create the Add City form to get information from the user
        // TODO 03c: Create an AddCity (POST) method to get the form data and call the dao to add a city
        // TODO 03d: Create the confirmation (Get) method to read the added city and call the view
        // TODO 03e: Create the Confirmation page to show the successful Add

        // TODO 05: Create a City Detail page
        // TODO 05a: Create a Detail (GET) method to handle the request and show the form
        // TODO 05b: Create the City Detail form to show information from the user. Include links to UPD and DEL.

        // TODO 06: Implement the PRG pattern to DELETE a city
        // TODO 06a: Create a Delete (GET) method to handle the request and show the form
        // TODO 06b: Create the Delete City form to show information to the user and confirm
        // TODO 06c: Create a Delete (POST) method to call the dao to delete a city
        // TODO 06d: Create the confirmation (Get) method call the view to confirm
        // TODO 06e: Create the Confirmation page to show the successful Delete

        // TODO 07: Implement flow to UPDATE a city
        // TODO 07a: Create an Update (GET) method to handle the request and show the form
        // TODO 07b: Create the Update City form to show / get information to the user
        // TODO 07c: Create an Update (POST) method to call the dao to update a city
        // TODO 07d: Redirect to the Update (GET) page
    }
}