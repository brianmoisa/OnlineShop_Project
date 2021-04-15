using OnlineShop.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Repository
{
    public class Mapper:IMapper
    {
        public ApplicationUser MapareViewModelLaUser_Inregistrare(InregistrareViewModel utilizator)
        {
            var user = new ApplicationUser
            {
                UserName = utilizator.Email,
                Email = utilizator.Email,
                PhoneNumber = utilizator.Telefon,
                FirstName = utilizator.Prenume,
                LastName = utilizator.Nume,
                UserType = "C",
                PasswordUpdateOn = DateTime.Now
            };

            return user;
        }

        
    }
}
