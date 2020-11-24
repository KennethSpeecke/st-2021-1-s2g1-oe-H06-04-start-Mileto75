using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.RateAMovie.Web.ViewModels;

namespace Wba.Oefening.RateAMovie.Web.Controllers
{
    public class MovieController : Controller
    {
        [Route("movie/add")]
        [HttpGet]
        public IActionResult AddMovie()
        {
            //toont een lijst van movies

            return View();
        }

        [Route("movie/add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMovie(MovieAddMovieVm movieAddMovieVm)
        {
            if (ModelState.IsValid)
            {
                //check als movie bestaat(fout aan model toevoegen)
                //indien niet => voeg hem toe
            }
            return View(movieAddMovieVm);
        }
    }
}
