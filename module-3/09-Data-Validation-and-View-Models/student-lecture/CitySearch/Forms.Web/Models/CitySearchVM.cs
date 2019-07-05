using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class CitySearchVM
    {
        public string CountryCode { get; set; }
        public string District { get; set; }
        public IList<City> Cities { get; set; }

        // Generate Select List from the DAO
        // Add a place to store a list of countries to the view-model
        public SelectList CountryList { get; set; }

    }
}
