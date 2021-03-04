using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public ApplicationUser GetUserType(LogareViewModel utilizator)
        {
            ApplicationUser utiliz = new ApplicationUser();
            utiliz = context.Utilizator.FirstOrDefault(x => x.Email == utilizator.Email);

            return utiliz;
        }


        public ApplicationUser DetaliiContUtilizator()
        {
            var user = httpContextAccessor.HttpContext.User.Identity;
            ApplicationUser utilizator = context.Utilizator.FirstOrDefault(x => x.Email == user.Name);

            return utilizator;
        }


    }
}
