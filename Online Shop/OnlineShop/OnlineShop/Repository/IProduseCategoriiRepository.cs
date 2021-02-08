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
       ProduseCategoriiViewModel GetProduseCategorii(string idCateg);
       Produs GetProdus(int id);
    }
}
