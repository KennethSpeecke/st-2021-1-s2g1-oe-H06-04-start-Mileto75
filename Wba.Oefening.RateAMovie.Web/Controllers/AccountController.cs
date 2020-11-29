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
        public async Task<IActionResult> Register(AccountRegisterVm accountRegisterVm)
        {
            if(ModelState.IsValid)
            {
                //check als user reeds bestaat
                if(await _movieContext.Users
                    .AnyAsync(u => u.Username.Equals(accountRegisterVm.userName)))
                {
                    ModelState.AddModelError("", "Username already taken!");
                    return View(accountRegisterVm);
                }
                //indien niet voeg user toe
                //enkel een voorbeeld, nooit plaintext opslaan
                //normaal gezien zal hier een password hash worden toegepast!
                //zie hiervoor: https://docs.microsoft.com/en-us/aspnet/core/security/data-protection/consumer-apis/password-hashing?view=aspnetcore-2.1
               
                var user = new User
                {
                    Username = accountRegisterVm?.userName,
                    Password = accountRegisterVm?.Password
                };
                //add to dbcontext
                _movieContext.Users.Add(user);
                //save to db
                try
                {
                    await _movieContext.SaveChangesAsync();
                }
                catch(DbUpdateException e)
                {
                    //use tempdata hier
                    //stuur terug naar register
                    return RedirectToAction("Register");

                }
                //use tempdata hier
                //set session hier
                //redirect naar Registered
                return RedirectToAction("Registered");

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
        public async Task<IActionResult> Login(AccountLoginVm accountLoginVm)
        {
            if(ModelState.IsValid)
            {
                //check userinfo uit database
                if(await _movieContext.Users
                    .AnyAsync(u => u.Username.Equals(accountLoginVm.userName))
                    &&
                    await _movieContext.Users
                    .AnyAsync(u => u.Password.Equals(accountLoginVm.Password)
                    ))
                {
                    //set session
                    //set tempdata message
                    //send to movies list
                    return RedirectToAction("Index", "Movie");
                }
                //indien foutief => voeg modelstate error toe
                ModelState.AddModelError("", "Wrong credentials!");
                
            }
            //stuur terug naar login
            return View(accountLoginVm);
        }
    }
}
