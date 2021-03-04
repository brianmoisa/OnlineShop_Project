using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Repository;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    public class ContController : Controller
    {
        private readonly IContRepository service;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ContController(IContRepository service,UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.service = service;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Logare()
        {
            return View();
        }

        public IActionResult Inregistrare()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Inregistrare(InregistrareViewModel utilizator)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = utilizator.Email, Email = utilizator.Email, PhoneNumber = utilizator.Telefon, FirstName = utilizator.Prenume, LastName = utilizator.Nume, UserType = "C" };
                var result = await userManager.CreateAsync(user, utilizator.Parola);

                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
 
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(utilizator);
        }

        [HttpPost]
        public async Task<IActionResult> Logare(LogareViewModel utilizator)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(utilizator.Email, utilizator.Parola, utilizator.RememberMe, false);

                if (result.Succeeded)
                {
                    var utiliz = service.GetUserType(utilizator);
                    if (utiliz.UserType == "A")
                        return RedirectToAction("Index", "Home");
                    //else
                    //return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Logare nereusita!");

            }
            return View(utilizator);
        }


        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> DetaliiCont(string descriere)
        {
            var user = await userManager.GetUserAsync(User);
            if (user==null)
                return View("Logare");
            else
            {
                ViewBag.Mesaj = descriere;
                return View();
            }
                
        }

        public IActionResult Partial(string numeTab)
        {
            ApplicationUser utilizator = service.DetaliiContUtilizator();
            DetaliiUtilizatorViewModel detalii = null;
            switch (numeTab){
                case "_Profil":
                     detalii = new DetaliiUtilizatorViewModel
                    {
                        Email = utilizator.Email,
                        Nume = utilizator.LastName,
                        Prenume = utilizator.FirstName,
                        Telefon = utilizator.PhoneNumber

                    };
                    break;
            }

            return PartialView(numeTab, detalii);

        }

        //public IActionResult SchimbareParola(SchimbareParolaViewModel parola)
        //{
        //    var result = service.SchimbareParola(parola);

        //    return RedirectToAction("DetaliiCont", new { descriere = "Parola schimbata cu succes" });
        //}
    }
}