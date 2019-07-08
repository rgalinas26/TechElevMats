using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class City
    {
        /*** Model validations
         * Name: Required
         * CountryCode: Display Name = Country Code, Required, String Length = 3
         * District: Required
         * Population: Required, Range 1-99,999,999
         ***/
        public int CityId { get;  set; }

        [Required(ErrorMessage = "*")]
        public string Name { get;  set; }

        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Country Code must be exactly 3  characters.")]
        [Display(Name="Country Code", Prompt="e.g., \"USA\"")]
        public string CountryCode { get;  set; }

        [Required]
        public string District { get; set; }

        [Range(1, 99999999, ErrorMessage="Population must be a positive number < one hundred million!")]
        public int Population { get;  set; }
    }
}
