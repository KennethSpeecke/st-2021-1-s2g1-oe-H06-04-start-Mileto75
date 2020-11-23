using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wba.Oefening.RateAMovie.Web.Data;
using Wba.Oefening.RateAMovie.Web.ViewModels;

namespace Wba.Oefening.RateAMovie.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly MovieContext _movieContext;

        public AccountController(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        [Route("/account/register")]
        [HttpGet]
        public IActionResult Register()
        {
            AccountRegisterVm accountRegisterVm = new AccountRegisterVm();
            return View(accountRegisterVm);
        }
        [Route("/account/register")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(AccountRegisterVm accountRegisterVm)
        {
            if(ModelState.IsValid)
            {
                //check als user reeds bestaat
                //indien niet voeg user toe
                //redirect naar Registered

            }
            return View(accountRegisterVm);
        }

        [HttpGet]
        [Route("/account/registered")]
        public IActionResult Registered()
        {
            return View();
        }

        [HttpGet]
        [Route("/account/login")]
        public IActionResult Login()
        {
            AccountLoginVm accountLoginVm = new AccountLoginVm();
            return View(accountLoginVm);
        }

        [HttpPost]
        [Route("/account/login")]
        public IActionResult Login(AccountLoginVm accountLoginVm)
        {
            if(ModelState.IsValid)
            {
                //check userinfo uit database
                //indien foutief => voeg modelstate error toe
                //en stuur terug naar login

                //indien correct => stuur naar movie lijst
            }
            return View(accountLoginVm);
        }
    }
}
