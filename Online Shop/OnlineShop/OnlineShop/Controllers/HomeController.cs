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




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        
    }
}
