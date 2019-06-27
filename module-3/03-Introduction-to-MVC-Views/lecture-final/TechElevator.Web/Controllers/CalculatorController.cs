using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechElevator.Web.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index(int? maxKPH)
        {
            if (maxKPH.HasValue)
            {
                ViewData["max"] = maxKPH.Value;
            }
            else
            {
                ViewData["max"] = 200;
            }
            return View();
        }
    }
}