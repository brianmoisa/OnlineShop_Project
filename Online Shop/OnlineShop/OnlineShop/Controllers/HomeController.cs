﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Repository;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProdusePromoRepository service;

        public HomeController(IProdusePromoRepository service)
        {
            this.service = service;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        
    }
}
