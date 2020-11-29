using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wba.Oefening.RateAMovie.Domain.Entities;
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
        [HttpGet]
        [Route("/Movie/Index")]
        [Route("/Movie/")]
        
        public async Task<IActionResult> Index()
        {
            //viewModel
            MovieIndexVm movieIndexVm = new MovieIndexVm();
            //get the movies
            movieIndexVm.Movies = await _movieContext.Movies.ToListAsync();
            //pass to model
            return View(movieIndexVm);
        }
        
        [Route("/Movie/Add")]
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

        [Route("Movie/Add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMovie(MovieAddMovieVm movieAddMovieVm)
        {
            //vul de selectlijsten opnieuw
            movieAddMovieVm.Companies = _selectListBuilder.BuildCompaniesList
                (_movieContext.Companies.ToList());
            movieAddMovieVm.Directors = _selectListBuilder.BuildDirectorList
                (_movieContext.Directors.ToList());
            if (ModelState.IsValid)
            {
                //check als movie bestaat(fout aan model toevoegen)
                //indien niet => voeg hem toe
                if(await _movieContext
                    .Movies
                    .AnyAsync(m => m.Title.Equals(movieAddMovieVm.Title)))
                {
                    ModelState.AddModelError("","Movie bestaat reeds!");
                    return View(movieAddMovieVm);
                }
                //store movie
                var movie = new Movie();


                movie.Title = movieAddMovieVm?.Title;
                movie.ReleaseDate = movieAddMovieVm?.ReleaseDate;
                movie.CompanyId = movieAddMovieVm.CompanyId;
                movie.Directors = new List<MovieDirector>
                {
                    new MovieDirector{Movie = movie,DirectorId=movieAddMovieVm.DirectorId}
                };
                //add to dbcontext
                _movieContext.Movies.Add(movie);
                //save to db
                try
                {
                    await _movieContext.SaveChangesAsync();
                    //use tempdata later on
                    return RedirectToAction("AddMovie");
                }
                catch(DbUpdateException e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    //use tempdata later on
                    return View(movieAddMovieVm);
                }
            }
            return View(movieAddMovieVm);
        }
        
        [HttpPost]
        [Route("/Movie/AddDirectorsToMovie/{Id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDirectorsToMovie(MovieAddDirectorsVm
            movieAddDirectorsVm)
        {
            //check if any director selected
            if(movieAddDirectorsVm.Directors
                .Where(d => d.IsSelected == true).Count() == 0)
            {
                ModelState.AddModelError("","Please select at least one director!");
                return View(movieAddDirectorsVm);
            }
            //store directors
            //1 remove all existing connections
            _movieContext.MovieDirectors.RemoveRange(_movieContext.MovieDirectors
                .Where(md => md.MovieId == movieAddDirectorsVm.MovieId));
            //loop over selected directors
            foreach(var moviedirector in movieAddDirectorsVm.Directors.Where(md =>md.IsSelected))
            {
                _movieContext.MovieDirectors.Add
                    (
                        new MovieDirector 
                        { 
                            MovieId = movieAddDirectorsVm.MovieId,
                            DirectorId = moviedirector.Id
                        }
                    );
            }
            try
            {
                await _movieContext.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                ModelState.AddModelError("", "Unknown error, try again later!");
                return View(movieAddDirectorsVm);
            }
            //back to form with movieId
            return RedirectToAction("AddDirectorsToMovie",movieAddDirectorsVm.MovieId);
        }

        [HttpGet]
        [Route("/Movie/AddDirectorsToMovie/{Id}")]
        public async Task<IActionResult> AddDirectorsToMovie(long Id)
        {
            //get the movie with directors
            var movie = await _movieContext.Movies
                .Include(m => m.Directors)
                .ThenInclude(d => d.Director)
                .FirstOrDefaultAsync
                (m => m.Id == Id);
            //Get the directors
            var directors = await  _movieContext.Directors.ToListAsync();
            
            //viewModel
            MovieAddDirectorsVm movieAddDirectorsVm
                = new MovieAddDirectorsVm();
            //add movie
            movieAddDirectorsVm.Title = movie?.Title;
            movieAddDirectorsVm.MovieId = movie?.Id;
            //ad directors
            foreach(var director in directors)
            {
                movieAddDirectorsVm.Directors.Add
                    (new DirectorCheckBox
                    {
                        Id = director?.Id,
                        Name = $"{director?.FirstName} {director?.LastName}",
                        IsSelected = false
                    });
            }
            //set the checkboxes for existing directors
            foreach (var movieDirectorvm in movieAddDirectorsVm.Directors)
            {
                if (movie.Directors.Any(d => d.DirectorId == movieDirectorvm.Id))
                {
                    movieDirectorvm.IsSelected = true;                        
                }
            }
            return View(movieAddDirectorsVm);
        }


        [HttpGet]
        [Route("/Movie/ConfirmDelete/{Id}")]
        public IActionResult DeleteMovieConfirm(long Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        [HttpGet]
        [Route("/Movie/Delete/{Id}")]
        public async Task<IActionResult> DeleteMovie(long Id)
        {
            //get the movie 
            var movieToDelete = await _movieContext
                .Movies
                .FirstOrDefaultAsync(m => m.Id == Id);
            _movieContext.Movies.Remove(movieToDelete);
            try
            {
                await _movieContext.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                //handle error messages to user using tempdata
                
            }
            return RedirectToAction("Index");
        }
    }
}
