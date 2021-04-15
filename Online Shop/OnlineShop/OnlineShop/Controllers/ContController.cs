using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.Repository;
using OnlineShop.ViewModels;

namespace OnlineShop.Controllers
{
    public class ContController : Controller
    {
        private readonly IContRepository _cont;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailservice;
        private readonly IEmailSender _emailSender;

        public ContController(IContRepository cont,IMapper mapper, /*IEmailService emailservice,*/ IEmailSender emailSender)
        {
            _cont = cont;
            _mapper = mapper;
            //_emailservice = emailservice;
            _emailSender = emailSender;
        }
        
        public IActionResult Logare()
        {
            return View();
        }


        public IActionResult Inregistrare() => View();

        [HttpPost]
        public async Task<IActionResult> Inregistrare(InregistrareViewModel utilizator)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.MapareViewModelLaUser_Inregistrare(utilizator);
                var result = await _cont.Inregistrare(user,utilizator.Parola);

                if (result.Succeeded)
                {
                    var token = await _cont.GenerareTokenEmail(user);

                    var link = Url.Action(nameof(ConfirmareCont), "Cont", new { userId = user.Id, token },Request.Scheme,Request.Host.ToString());

                    //await _emailservice.SendAsync(user.Email, "Confirmare cont",link);
                    await _emailSender.SendEmailAsync(user.Email, "Confirmare cont",$"<a href=\"{link}\">Confirmare cont</a>");

                    return RedirectToAction("VerificareEmail");

                }
                    

                //return RedirectToAction("Index", "Home");

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

            }

            return View(utilizator);
        }

        public async Task<IActionResult> ConfirmareCont(string userId,string token)
        {
            if(userId == null || token ==null)
            {
                return RedirectToAction("Index", "Home");
            }
            var result = await _cont.ConfirmareCont(userId, token);
            if (result==null)
            {
                ViewBag.ErrorMessage = $"Utilizatorul este incorect!";
                return View("NotFound");
            }

            if(result.Succeeded)
                 return View();

            ViewBag.ErrorTitle = "Contul nu a putut fi confirmat!";
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Logare(LogareViewModel utilizator)
        {
            if (ModelState.IsValid)
            {

                if( await _cont.VerificareEmailConfirmat(utilizator.Email,utilizator.Parola))
                {
                    ModelState.AddModelError(string.Empty, "Contul nu este inca confirmat!");
                    return View(utilizator);
                }

                var result = await _cont.Logare(utilizator);
                if (result.Succeeded)
                {
                    var utiliz = _cont.ObtineTipUtilizator(utilizator);
                    if (utiliz.UserType == "A")
                        return RedirectToAction("Index", "Home");
                    //else
                    //return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Logare nereusita!");

            }
            return View(utilizator);
        }


        public IActionResult Logout()
        {
            _cont.Delogare();
            return RedirectToAction("Index", "Home");
        }


        public IActionResult DetaliiCont(string descr)
        {

            var user = _cont.ObtineUtilizator();
            if (user==null)
                return RedirectToAction("Logare");
            else
            {
                DetaliiContViewModel model = new DetaliiContViewModel()
                {
                    Nume = user.LastName,
                    Prenume = user.FirstName,
                    PasswordUpdateOn = user.PasswordUpdateOn,
                    Email = user.Email,
                    Telefon = user.PhoneNumber
                };

                return View(model);
            }    
        }


        public IActionResult SchimbareParola()
        {
            var user = _cont.ObtineUtilizator();
            if (user == null)
                return RedirectToAction("Logare");
            else
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> SchimbareParola(SchimbareParolaViewModel parola)
        {

            if (ModelState.IsValid)
            {

                //var user = await userManager.GetUserAsync(User);
                //var result = await userManager.ChangePasswordAsync(user, parola.ParolaVeche, parola.ParolaNoua);

                var result = await _cont.SchimbareParola(parola);
                if (result.Succeeded)
                {
                    _cont.ModificareDataSchimbareParola();
                    ViewBag.SuccessMessage = "Parola schimbata cu succes!";
                    return View("SchimbareDetaliiCont");
                }
                foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(parola);
        }


        public IActionResult VerificareEmail() => View();



        //public IActionResult Partial(string numeTab)
        //{
        //    ApplicationUser utilizator = service.DetaliiContUtilizator();
        //    DetaliiUtilizatorViewModel detalii = null;
        //    switch (numeTab)
        //    {
        //        case "_Profil":
        //            detalii = new DetaliiUtilizatorViewModel
        //            {
        //                Email = utilizator.Email,
        //                Nume = utilizator.LastName,
        //                Prenume = utilizator.FirstName,
        //                Telefon = utilizator.PhoneNumber

        //            };
        //            break;
        //    }

        //    return PartialView(numeTab, detalii);

        //}


    }
}