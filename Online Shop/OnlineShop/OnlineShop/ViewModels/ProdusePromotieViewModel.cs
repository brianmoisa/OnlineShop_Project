using OnlineShop.Classes;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.ViewModels
{
    public class ProdusePromotieViewModel
    {
        public IEnumerable<Produs> produse { get; set; }
        public IEnumerable<Produs_promotie> produs_promo {get; set;}
    }
}
