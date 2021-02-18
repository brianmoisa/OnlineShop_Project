using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Repository;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository service;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public HomeController(IHomeRepository service, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.service = service;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            ProdusePromotieViewModel prod_prom = new ProdusePromotieViewModel();
            prod_prom.produse = service.GetProducts();
            prod_prom.produs_promo = service.GetProductsPromo();

            return View(prod_prom);
        }

        public IActionResult Logare()
        {
            //try
            //{
            //    Convert.ToInt16("dada");
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}

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
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

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
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(utilizator.Email, utilizator.Parola, utilizator.RememberMe, false);
            

            if(result.Succeeded)
                {
                    var utiliz = service.GetUserType(utilizator);
                    if(utiliz.UserType == "A")
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

        public async Task<IActionResult> DetaliiCont()
        {
            ApplicationUser utilizator = await userManager.GetUserAsync(HttpContext.User);
            if (utilizator == null)
                return View("Logare");
            else
            return View();
        }
        public async Task<IActionResult> Partial(string str)
        {
            ApplicationUser utilizator = await userManager.GetUserAsync(HttpContext.User);
            DetaliiUtilizatorViewModel detalii = new DetaliiUtilizatorViewModel
            {
                Email = utilizator.Email,
                Nume = utilizator.LastName,
                Prenume = utilizator.FirstName,
                Telefon = utilizator.PhoneNumber

            };
            return View(str,detalii);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        
    }
}
