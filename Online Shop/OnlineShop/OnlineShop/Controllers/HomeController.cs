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
                var user = new ApplicationUser { UserName = utilizator.Email, Email = utilizator.Email, PhoneNumber = utilizator.Telefon, FirstName=utilizator.Prenume, LastName=utilizator.Nume };
                var result = await userManager.CreateAsync(user, utilizator.Parola);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index","Home");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(utilizator);
        }

        //[HttpPost]
        //public async Task<IActionResult> Logare(LogareViewModel user)
        //{
        //    Utilizator utiliz = new Utilizator();
        //    utiliz = service.GetUser(user);
            
        //    if (utiliz == null)
        //    {
        //        var Msg = "Invalid";
        //        return View();
        //    }
        //    else
        //    {
        //       // var claims = new List<Claim>{
        //       // new Claim(ClaimTypes.Name, utiliz.Email),
        //       //     new Claim("Full name", utiliz.Nume)
        //       // };
                

        //       //var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        //       // var authProperties = new AuthenticationProperties
        //       // {

        //       // };
        //       // await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
        //       //     authProperties
        //       //     );
        //       // string returnUrl = Url.Content("~/");
        //       // return RedirectToAction("Index",returnUrl);
        //    }

            
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        
    }
}
