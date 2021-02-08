using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.ViewModels
{
    public class ProduseCategoriiViewModel
    {
       public IEnumerable<Produs> Produse { get; set; }
       public IEnumerable<Subcategorie> Subcategorie { get; set; }
       public string titluPagina { get; set; }
    }
}
