using OnlineShop.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Repository
{
    public interface IMapper
    {
        ApplicationUser MapareViewModelLaUser_Inregistrare(InregistrareViewModel utilizator);
       
    }
}
