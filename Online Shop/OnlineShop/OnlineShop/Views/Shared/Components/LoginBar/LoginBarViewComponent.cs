using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Views.Shared.Components.LoginBar
{
    public class LoginBarViewComponent: ViewComponent
    {
     
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
