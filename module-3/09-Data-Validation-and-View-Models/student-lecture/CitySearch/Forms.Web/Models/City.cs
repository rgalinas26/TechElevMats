using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class City
    {
        /*** TODO 03: Add model validations
         * Name: Required
         * CountryCode: Display Name = Country Code, Required, String Length = 3
         * District: Required
         * Population: Required, Range 1-99,999,999
         ***/
        public int CityId { get;  set; }
        public string Name { get;  set; }

        [Display(Name="Country Code", Prompt="e.g., \"USA\"")]
        public string CountryCode { get;  set; }

        public string District { get;  set; }

        public int Population { get;  set; }
    }
}
