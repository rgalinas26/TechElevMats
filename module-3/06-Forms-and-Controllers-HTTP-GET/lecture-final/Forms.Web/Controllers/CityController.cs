using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Web.DAL;
using Forms.Web.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Search(CitySearchVM vm)
        {
            if (vm.CountryCode != null)
            {
                // Use the dao to get the cities that match the search
                vm.Cities = cityDAO.GetCities(vm.CountryCode, vm.District);
            }

            // Pass the results into the SearchResults view for display
            return View(vm);
        }

        //public IActionResult SearchResults(CitySearchVM vm)
        //{
        //    //CitySearchVM vm = new CitySearchVM();
        //    //vm.CountryCode = countryCode;
        //    //vm.District = district;
        //    // Use the dao to get the cities that match the search
        //    vm.Cities = cityDAO.GetCities(vm.CountryCode, vm.District);

        //    // Pass the results into the SearchResults view for display
        //    return View(vm);
        //}
    }
}