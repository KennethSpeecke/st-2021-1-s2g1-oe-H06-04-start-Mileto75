using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wba.Oefening.RateAMovie.Web.Data;
using Wba.Oefening.RateAMovie.Web.Helpers;
using Wba.Oefening.RateAMovie.Web.ViewModels;

namespace Wba.Oefening.RateAMovie.Web.Controllers
{
    
    public class MovieController : Controller
    {
        private readonly MovieContext _movieContext;
        private readonly SelectListBuilder _selectListBuilder;
        public MovieController(MovieContext movieContext)
        {
            _movieContext = movieContext;
            _selectListBuilder = new SelectListBuilder();
        }
        [Route("movie/add")]
        [HttpGet]
        public async Task<IActionResult> AddMovie()
        {
            //viewmodel
            MovieAddMovieVm movieAddMovieVm = new MovieAddMovieVm();
            //vul datum
            movieAddMovieVm.ReleaseDate = DateTime.Now;
            //vul lijsten
            movieAddMovieVm.Companies = _selectListBuilder.BuildCompaniesList
                (await _movieContext.Companies.ToListAsync());
            movieAddMovieVm.Directors = _selectListBuilder.BuildDirectorList
                (await _movieContext.Directors.ToListAsync());
            return View(movieAddMovieVm);
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
            //vul de selectlijsten opnieuw
            movieAddMovieVm.Companies = _selectListBuilder.BuildCompaniesList
                (_movieContext.Companies.ToList());
            movieAddMovieVm.Directors = _selectListBuilder.BuildDirectorList
                (_movieContext.Directors.ToList());
            return View(movieAddMovieVm);
        }
    }
}
