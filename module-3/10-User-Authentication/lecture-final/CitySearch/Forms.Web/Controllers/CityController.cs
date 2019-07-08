using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Web.DAO;
using Forms.Web.Models;
using Forms.Web.Providers.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forms.Web.Controllers
{
    public class CityController : AppController
    {
        private ICityDAO cityDAO;
        public CityController(IAuthProvider authProvider, ICityDAO cityDAO) : base(authProvider)
        {
            this.cityDAO = cityDAO;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Search");
        }

        // Detail screen for city
        [HttpGet]
        // TODO: Protect City/Detail with AuthorizeFilter so the user must be logged in (any role)
        [AuthorizationFilter]
        public IActionResult Detail(int id)
        {
            CityVM vm = new CityVM(GetCurrentUser());
            vm.City = cityDAO.GetCityById(id);
            if (vm.City == null)
            {
                return NotFound();
            }

            return View(vm);
        }


        // TODO: Protect City/Search with AuthorizeFilter so the user must be logged in (any role)
        [HttpGet]
        [AuthorizationFilter]
        public IActionResult Search(CitySearchVM vm)
        {
            if (vm.CountryCode != null)
            {
                // Use the dao to get the cities that match the search
                vm.Cities = cityDAO.GetCities(vm.CountryCode, vm.District);
            }

            // Call the GetCountries private method, which Populates the country list on the view model
            vm.CountryList = GetCountries();

            // Make sure the current user is available
            vm.CurrentUser = GetCurrentUser();

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
        // TODO: Protect City/Add with AuthorizeFilter so the user must be logged in (Admin)
        [AuthorizationFilter("Admin")]
        public IActionResult Add()
        {
            CityVM vm = new CityVM(GetCurrentUser());
            return View(vm);
        }

        [HttpPost]
        // TODO: Protect City/Add with AuthorizeFilter so the user must be logged in (Admin)
        [AuthorizationFilter("Admin")]
        public IActionResult Add(CityVM cityVM)
        {
            // Check model state before updating. If there are errors, return the form to the user.
            if (!ModelState.IsValid)
            {
                return View(cityVM);
            }

            // Use the dao to add the city
            int newCityId = cityDAO.AddCity(cityVM.City);

            // Store a message in TempData to be shown to the user
            TempData["message"] = $"The city '{cityVM.City.Name}' was added. The new city ID is {newCityId}.";
            TempData["HighlightId"] = newCityId;

            // Redirect from add to search, passing Country and District in
            CitySearchVM vm = new CitySearchVM(GetCurrentUser())
            {
                CountryCode = cityVM.City.CountryCode,
                District = cityVM.City.District
            };
            return RedirectToAction("Search", vm);
        }

        [HttpGet]
        // TODO: Protect City/Update with AuthorizeFilter so the user must be logged in (Admin)
        [AuthorizationFilter("Admin")]
        public IActionResult Update(int id)
        {
            CityVM vm = new CityVM(GetCurrentUser());
            vm.City = cityDAO.GetCityById(id);
            if (vm.City == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        [HttpPost]
        // TODO: Protect City/Update with AuthorizeFilter so the user must be logged in (Admin)
        [AuthorizationFilter("Admin")]
        public IActionResult Update(City city)
        {
            // Check model state before updating. If there are errors, return the form to the user.
            if (!ModelState.IsValid)
            {
                return View(city);
            }

            // Use the dao to add the city
            cityDAO.UpdateCity(city);

            // Store a message in TempData to be shown to the user
            TempData["message"] = $"The city '{city.Name}' was updated.";
            TempData["HighlightId"] = city.CityId;

            // Redirect from add to search, passing Country and District in
            CitySearchVM vm = new CitySearchVM(GetCurrentUser())
            {
                CountryCode = city.CountryCode,
                District = city.District
            };
            return RedirectToAction("Search", vm);
        }


        [HttpGet]
        // TODO: Protect City/Delete with AuthorizeFilter so the user must be logged in (Admin)
        [AuthorizationFilter("Admin")]
        public IActionResult Delete(int id)
        {
            // Show the view which asks the user to confirm deletion
            CityVM vm = new CityVM(GetCurrentUser());
            vm.City = cityDAO.GetCityById(id);
            if (vm.City == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        [HttpPost]
        // TODO: Protect City/Delete with AuthorizeFilter so the user must be logged in (Admin)
        [AuthorizationFilter("Admin")]
        public IActionResult Delete(City city)
        {
            // Get the city 
            city = cityDAO.GetCityById(city.CityId);
            if (city == null)
            {
                return NotFound();
            }

            // Delete the city
            cityDAO.DeleteCity(city.CityId);

            // Redirect from delete to search, passing Country and District in
            CitySearchVM vm = new CitySearchVM(GetCurrentUser())
            {
                CountryCode = city.CountryCode,
                District = city.District
            };

            // Store a message in TempData to be shown to the user
            TempData["message"] = $"The city '{city.Name}' was deleted.";
            return RedirectToAction("Search", vm);
        }
    }
}