using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TechElevator.Web.Controllers
{
    public class HomeController : Controller
    {
        // TODO 01: Modify the Home/Index view 
        public IActionResult Index()
        {
            return View();
        }

        // TODO 02: Add a Greeting Action to this controller and its related Home/Greeting view


        // TODO 04: Add a Calculators Controller  http://localhost/Calculators/
        // TODO 05: Add an Index view as the default page. Calculate MPH for all KPH from 0 to 100 KPH
        // TODO 06: Add a KPH parameter to the action, and pass it to the view. Use that value to cap the loop.
    }
}