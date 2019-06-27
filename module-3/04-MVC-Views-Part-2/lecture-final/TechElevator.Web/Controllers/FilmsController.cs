using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechElevator.Web.DAL;
using TechElevator.Web.Models;

namespace TechElevator.Web.Controllers
{
    public class FilmsController : Controller
    {
        public IActionResult Index()
        {
            // Get a list of all films (our Model)
            IStarWarsDAO dao = new MockStarWarsDAO();
            IList<Film> films = dao.GetFilms();

            return View(films);
        }

        public IActionResult Detail(string id)
        {
            IStarWarsDAO dao = new MockStarWarsDAO();
            Film film = dao.GetFilm(id);

            if (film == null)
            {
                return NotFound();

            }
            else
            {
                return View(film);
            }
        }
    }
}