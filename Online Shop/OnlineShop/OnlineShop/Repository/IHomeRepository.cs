using Microsoft.AspNetCore.Identity;
using OnlineShop.Classes;
using OnlineShop.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Repository
{
    public interface IHomeRepository
    {
        IEnumerable<Produs> GetProducts();
        IEnumerable<Produs_promotie> GetProductsPromo();
        ApplicationUser GetUserType(LogareViewModel utilizator);


        //void AddUser(InregistrareViewModel user);
        //Utilizator GetUser(LogareViewModel user);
    }
}
