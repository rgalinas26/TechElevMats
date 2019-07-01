using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class CitySearchVM
    {
        public string CountryCode { get; set; }
        public string District { get; set; }
        public IList<City> Cities { get; set; }
    }
}
