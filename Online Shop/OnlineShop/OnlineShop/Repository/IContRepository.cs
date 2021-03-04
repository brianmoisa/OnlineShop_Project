using Microsoft.AspNetCore.Identity;
using OnlineShop.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShop.Repository
{
    public interface IContRepository
    {

        ApplicationUser GetUserType(LogareViewModel utilizator);
        ApplicationUser DetaliiContUtilizator();
    }
}
