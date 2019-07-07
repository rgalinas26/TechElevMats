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

            // Call the GetCountries private method, which Populates the country list on the view model
            vm.CountryList = GetCountries();

            // Pass the results into the SearchResults view for display
            return View(vm);
        }

        // Create a method which creates a list of SelectListItems for a dropdown
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

            // TODO 05: Check model state before updating. If there are errors, return the form to the user.
            if (!ModelState.IsValid)
            {
                return View(city);
            }

            // Use the dao to add the city
            int newCityId = cityDAO.AddCity(city);

            // TODO 02a: Store a message in TempData to be shown to the user
            TempData["message"] = $"The city '{city.Name}' was added. The new city ID is {newCityId}.";

            // Redirect to a confirmation page
            //return RedirectToAction("AddConfirmation", new { id = newCityId });
            // TODO 01: Redirect from add to search, passing Country and District in
            CitySearchVM vm = new CitySearchVM()
            {
                CountryCode = city.CountryCode,
                District = city.District
            };
            return RedirectToAction("Search", vm);
        }

        [HttpGet]
        public IActionResult AddConfirmation(int id)
        {
            City city = cityDAO.GetCityById(id);
            return View(city);
        }

        // TODO BONUS 01: Create a City Detail page
        // TODO BONUS 01a: Create a Detail (GET) method to handle the request and show the form
        // TODO BONUS 01b: Create the City Detail form to show information from the user. Include links to UPD and DEL.

        // TODO BONUS 02: Implement the PRG pattern to DELETE a city
        // TODO BONUS 02a: Create a Delete (GET) method to handle the request and show the form
        // TODO BONUS 02b: Create the Delete City form to show information to the user and confirm
        // TODO BONUS 02c: Create a Delete (POST) method to call the dao to delete a city
        // TODO BONUS 02d: Create the confirmation (Get) method call the view to confirm
        // TODO BONUS 02e: Create the Confirmation page to show the successful Delete

        // TODO BONUS 03: Implement flow to UPDATE a city
        // TODO BONUS 03a: Create an Update (GET) method to handle the request and show the form
        // TODO BONUS 03b: Create the Update City form to show / get information to the user
        // TODO BONUS 03c: Create an Update (POST) method to call the dao to update a city
        // TODO BONUS 03d: Redirect to the Update (GET) page
    }
}