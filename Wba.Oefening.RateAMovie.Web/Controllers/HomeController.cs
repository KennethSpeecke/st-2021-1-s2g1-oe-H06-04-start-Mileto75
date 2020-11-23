using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.RateAMovie.Web.Models;
using Wba.Oefening.RateAMovie.Web.ViewModels;

namespace Wba.Oefening.RateAMovie.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        [Route("/movies")]
        public IActionResult Index()
        {
            //toont een lijst van movies
            return View();
        }

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
        public IActionResult AddMovie(HomeAddMovieVm homeAddMovieVm)
        {
            if(ModelState.IsValid)
            {
                //check als movie bestaat(fout aan model toevoegen)
                //indien niet => voeg hem toe
            }
            return View(homeAddMovieVm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
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
