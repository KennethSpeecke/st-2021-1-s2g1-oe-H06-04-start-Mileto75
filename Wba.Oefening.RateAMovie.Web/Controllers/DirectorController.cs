using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wba.Oefening.RateAMovie.Domain.Entities;
using Wba.Oefening.RateAMovie.Web.Data;
using Wba.Oefening.RateAMovie.Web.ViewModels;

namespace Wba.Oefening.RateAMovie.Web.Controllers
{
    public class DirectorController : Controller
    {
        //dependency injection
        private readonly MovieContext _movieContext;
        public DirectorController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        //maak viewmodel
        //maak action methods GET POST
        //maak formulier in view
        //controleer modelstate
        //controleer of director reeds bestaat
        //sla op in database
        public IActionResult Index()
        {
            //toont een lijst van directors
            return View();
        }

        [HttpGet]
        [Route("/Director/Add")]
        public IActionResult AddDirector()
        {
            //maak viewmodel aan
            DirectorAddDirectorVm directorAddDirectorVm
                = new DirectorAddDirectorVm();
            return View(directorAddDirectorVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Director/Add")]
        public async Task<IActionResult> AddDirector
            (DirectorAddDirectorVm directorAddDirectorVm)
        {
            //check modelstate op formulierfouten
            if(!ModelState.IsValid)
            {
                return View(directorAddDirectorVm);
            }
            //check if director bestaat
            //eigenlijk overkill in geval van directors met dezelfde naam
            //Piet Pieters of Jan Janssen, ...
            if(_movieContext.Directors
                .Any(d => d.FirstName
                .Equals(directorAddDirectorVm.FirstName))
                &&
                _movieContext.Directors.Any(d => d.LastName
                .Equals(directorAddDirectorVm.LastName)))
            {
                //add custom modelstate error
                ModelState.AddModelError("", "Director bestaat reeds!");
                return View(directorAddDirectorVm);
            }
            //alles ok, bewaar director met object initiliazer
            var newdirector = new Director
            { 
                FirstName = directorAddDirectorVm?.FirstName,
                LastName = directorAddDirectorVm?.LastName
            };
            //voeg toe aan Dbcontext
            _movieContext.Directors.Add(newdirector);
            //stuur naar Database
            try
            { 
                await _movieContext.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                Console.WriteLine(e.InnerException.Message);
                ModelState
                    .AddModelError("", 
                    "Er heeft zich een onbekende fout voorgedaan!");
                return View(directorAddDirectorVm);
            }

            //opslaan gelukt: stuur terug naar leeg formulier
            return RedirectToAction("AddDirector");
        }

        //edit director
        [HttpGet]
        [Route("/Director/Edit/{Id}")]
        public async Task<IActionResult> EditDirector(long Id)
        {
            //maak view model
            DirectorEditDirectorVm directorEditDirectorVm = new DirectorEditDirectorVm();
            //haal de director info op uit Db
            var directorToEdit = await _movieContext
                .Directors
                .FirstOrDefaultAsync(d => d.Id == Id);
            //fill the model
            directorEditDirectorVm.FirstName = directorToEdit.FirstName;
            directorEditDirectorVm.LastName = directorToEdit.LastName;
            directorEditDirectorVm.Id = directorToEdit.Id;
            return View(directorEditDirectorVm);
        }

        //edit director
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/Director/Edit/{Id}")]
        public async Task<IActionResult> EditDirector(DirectorEditDirectorVm directorEditDirectorVm)
        {
            //check Modelstate
            if(!ModelState.IsValid)
            {
                return View(directorEditDirectorVm);
            }
            //bewaar edits
            //haal director op
            var directorToEdit = await _movieContext
                .Directors
                .FindAsync(directorEditDirectorVm.Id);
            //pas aan
            directorToEdit.FirstName = directorEditDirectorVm?.FirstName;
            directorToEdit.LastName = directorEditDirectorVm?.LastName;
            //bewaar
            try
            {
                await _movieContext.SaveChangesAsync();
            }
            catch(DbUpdateException e)
            {
                Console.WriteLine(e.InnerException.Message);
                ModelState
                    .AddModelError("",
                    "Er heeft zich een onbekende fout voorgedaan!");
                return View(directorEditDirectorVm);
            }
            return View();
        }

    }
}
