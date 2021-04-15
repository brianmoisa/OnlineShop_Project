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
        ApplicationUser ObtineUtilizator();
        ApplicationUser ObtineTipUtilizator(LogareViewModel utilizator);
        Task<IdentityResult> Inregistrare(ApplicationUser user,string parola);
        Task<SignInResult> Logare(LogareViewModel utilizator);
        Task<bool> VerificareEmailConfirmat(string email,string password);
        void Delogare();
        Task<IdentityResult> SchimbareParola(SchimbareParolaViewModel parola);
        void ModificareDataSchimbareParola();
        Task<string> GenerareTokenEmail(ApplicationUser user);
        Task<IdentityResult> ConfirmareCont(string userId, string token);

    }
}
