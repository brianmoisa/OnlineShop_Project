using System;
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
    public class ProduseController : Controller
    {
        private readonly IProduseCategoriiRepository _db;

        public ProduseController(IProduseCategoriiRepository db)
        {
            _db = db;
        }

        // [Route("/Produse/ProduseCurrent",
        //Name = "prod")]
        [HttpGet]
        [Route("Produse/Produse/{id}")]

        public IActionResult Produse(string id)
        {
            return View(_db.GetProduseCategorii(id));
        }

        [HttpGet]
        [Route("Produse/ProdusDetalii/{id}")]
        public IActionResult ProdusDetalii(int id)
        {

            return View(_db.GetProdus(id));
        }
    }
}