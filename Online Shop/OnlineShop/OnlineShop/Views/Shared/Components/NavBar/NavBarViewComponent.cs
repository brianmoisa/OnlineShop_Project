using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Views.Shared.Components
{
    public class NavBarViewComponent:ViewComponent
    {
        private readonly ApplicationDBContext _db;
        public NavBarViewComponent(ApplicationDBContext db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<Categorie> categorii = _db.Categorii;
            return View(categorii);
        }
    }
}
