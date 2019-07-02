using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forms.Web.Models;
using Forms.Web.DAL;

namespace Forms.Web.Controllers
{
    public class HomeController : Controller
    {        
        /// <summary>
        /// Represents an index action.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }   
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
