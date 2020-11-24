using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.RateAMovie.Domains.Entities;
using Wba.Oefening.RateAMovie.Web.Data;
using Wba.Oefening.RateAMovie.Web.ViewModels;

namespace Wba.Oefening.RateAMovie.Web.Controllers
{
    public class CompanyController : Controller
    {
        //dependency injection van onze DbContext
        private readonly MovieContext _movieContext;

        public CompanyController(MovieContext movieContext)
        {
            //injectie gebeurt hier
            _movieContext = movieContext;
        }
        public IActionResult Index()
        {
            //toont een lijst van companies
            return View();
        }
        //methodes om nieuwe company aan temaken
        [HttpGet]
        [Route("/Company/add")]
        public IActionResult AddCompany()
        {
            //viewmodel aanmaken
            CompanyAddCompanyVm companyAddCompanyVm
                = new CompanyAddCompanyVm();
            return View(companyAddCompanyVm);
        }
        [HttpPost]
        [Route("/Company/add")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCompany
            (CompanyAddCompanyVm companyAddCompanyVm)
        {
            if(!ModelState.IsValid)
            {
                return View(companyAddCompanyVm);
            }
            //extra check => bestaat company al?
            //gebruik de any methode
            if(_movieContext
                .Companies.Any(c =>c.Name.Equals(companyAddCompanyVm.Name)))
            {
                //custom error to modelstate
                ModelState.AddModelError("", "Company bestaat reeds!");
                return View(companyAddCompanyVm);
            }

            //company opslaan
            //maak nieuwe company entity
            var newCompany = new Company();
            newCompany.Name = companyAddCompanyVm?.Name;
            _movieContext.Companies.Add(newCompany);
            //stuur naar database
            await _movieContext.SaveChangesAsync();
            return RedirectToAction("AddCompany");
        }
    }
}
