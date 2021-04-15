using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineShop.Repository
{
    public class ContRepository: IContRepository
    {
        private readonly ApplicationDBContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ContRepository(ApplicationDBContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor _httpContextAccessor)
        {
            this.context = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.httpContextAccessor = _httpContextAccessor;
        }

        public ApplicationUser ObtineTipUtilizator(LogareViewModel utilizator)
        {
            ApplicationUser utiliz = new ApplicationUser();
            utiliz = context.Utilizator.FirstOrDefault(x => x.Email == utilizator.Email);

            return utiliz;
        }

        public async Task<IdentityResult> Inregistrare(ApplicationUser user, string parola)
        {
            return await userManager.CreateAsync(user, parola);
        }

        public async Task<SignInResult> Logare(LogareViewModel utilizator)
        {
            return await signInManager.PasswordSignInAsync(utilizator.Email, utilizator.Parola, utilizator.RememberMe, false);
        }

        public async void Delogare()
        {
            await signInManager.SignOutAsync();
        }


        public async Task<IdentityResult> SchimbareParola(SchimbareParolaViewModel parola)
        {
            var user = ObtineUtilizator();
            return  await userManager.ChangePasswordAsync(user, parola.ParolaVeche, parola.ParolaNoua);
        }

        public async void ModificareDataSchimbareParola()
        {
            var user = ObtineUtilizator();
            user.PasswordUpdateOn = DateTime.Now;
            await userManager.UpdateAsync(user);
            await signInManager.RefreshSignInAsync(user);
        }

        public ApplicationUser ObtineUtilizator()
        {
           var userId =  httpContextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            return context.Utilizator.FirstOrDefault(x => x.Id == userId);
        }


        public async Task<bool> VerificareEmailConfirmat(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            var parola = await userManager.CheckPasswordAsync(user, password);

            if(user!=null && !user.EmailConfirmed && parola)
                return true;
                    return false;
        }

        public async Task<string> GenerareTokenEmail(ApplicationUser user)
        {
            return await userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<IdentityResult> ConfirmareCont(string userId,string token)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
                return null;
            return await userManager.ConfirmEmailAsync(user, token);
        }

    }
}
