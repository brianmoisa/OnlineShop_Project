using OnlineShop.Classes;
using OnlineShop.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Repository
{
   public interface IProduseCategoriiRepository
    {
        IEnumerable<Produs> GetProductsByCategory(string idCateg);
        IEnumerable<Subcategorie> GetSubcategByCategory(string idCateg);
        Produs GetProdus(int id);
    }
}
