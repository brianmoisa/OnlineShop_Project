using OnlineShop.Classes;
using OnlineShop.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Repository
{
    public interface IProdusePromoRepository
    {
        IEnumerable<Produs> GetProducts();
        IEnumerable<Produs_promotie> GetProductsPromo();
    }
}
