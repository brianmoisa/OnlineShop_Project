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
        [Route("Produse/Categorie/{id}")]

        public IActionResult Categorie(string id)
        {
            ProduseCategoriiViewModel produse_categ = new ProduseCategoriiViewModel()
            {
                Produse = _db.GetProductsByCategory(id),
                Subcategorie = _db.GetSubcategByCategory(id)
            };

            if (produse_categ.Produse == null && produse_categ.Subcategorie == null)
            {
                Response.StatusCode = 404;
                return View("_ErrorView", "Categoria '"+id+"' introdusa nu a fost gasita!");
            }
            produse_categ.titluPagina = id;
            return View(produse_categ);
        }

        [HttpGet]
        [Route("Produse/ProdusDetalii/{id}")]
        public IActionResult ProdusDetalii(int id)
        {

            Produs prod = _db.GetProdus(id);
            if(prod == null)
            {
                Response.StatusCode = 404;
                return View("_ErrorView", "Produsul introdus nu a fost gasit!");
            }
            return View(_db.GetProdus(id));
        }
    }
}