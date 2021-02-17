using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using OnlineShop.Classes;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.ViewModels;

namespace OnlineShop.Repository
{
    public class HomeRepository:IHomeRepository
    {
        private readonly ApplicationDBContext context;


        public HomeRepository(ApplicationDBContext db)
        {
            context = db;
        }

        public IEnumerable<Produs> GetProducts()
        {
            string time = String.Format("{0:u}", DateTime.Now.AddDays(-30));
            string timeNow = String.Format("{0:u}", DateTime.Now);
            return context.Produse.Where(x=>x.DataAdaugare <= DateTime.Parse(timeNow) && x.DataAdaugare>= DateTime.Parse(time));
        }

        public IEnumerable<Produs_promotie> GetProductsPromo()
        {
            string timeNow = String.Format("{0:u}", DateTime.Now);
            List<Produs_promotie> prod_prom = new List<Produs_promotie>();
            float? pret_redus;
            var obj = from a in context.Produse
                      join b in context.Promotii_Produse
                      on a.Id_Produs equals b.Id_Produs
                      join c in context.Promotii
                      on b.Id_promotie equals c.Id_promotie
                      where c.Data_sfarsit < DateTime.Parse(timeNow)
                      select new
                      {
                          Id_Produs = a.Id_Produs,
                          Nume = a.Nume,
                          Descriere = a.Descriere,
                          Pret = a.Pret,
                          Poza = a.Poza,
                          Procentaj = b.Procentaj
                         
                      };
            foreach (var v in obj)
            {
                if (v.Procentaj is null)
                {
                    pret_redus = 0;
                }
                else
                {
                    pret_redus = v.Pret - (v.Procentaj * v.Pret)/100;
                }

                prod_prom.Add(new Produs_promotie { Id_Produs = v.Id_Produs, Nume = v.Nume, Descriere = v.Descriere, Pret = v.Pret, Poza = v.Poza, Pret_redus = pret_redus });
            }
            return prod_prom;

        }

        public ApplicationUser GetUserType(LogareViewModel utilizator)
        {
            ApplicationUser utiliz = new ApplicationUser();
            utiliz = context.Utilizator.FirstOrDefault(x => x.Email == utilizator.Email);

            return utiliz;
        }

        //public void AddUser(InregistrareViewModel user)
        //{
        //    Utilizator utilizator = new Utilizator();
        //    try
        //    {
        //        utilizator.Email = user.Email;
        //        utilizator.Parola = BCrypt.Net.BCrypt.HashPassword(user.Parola);
        //        utilizator.Nume = user.Nume;
        //        utilizator.Prenume = user.Prenume;
        //        utilizator.Telefon = user.Telefon;
        //        utilizator.Cont_activ = "A";
        //        context.Add(utilizator);
        //        context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }


        //}

        //public Utilizator GetUser(LogareViewModel user)
        //{
        //    Utilizator utiliz = new Utilizator();
        //    var account = context.Utilizatori.SingleOrDefault(x => x.Email == user.Email);
        //    if(account != null)
        //    {
        //        if (BCrypt.Net.BCrypt.Verify(user.Parola, account.Parola))
        //        {
        //            utiliz.Nume = account.Nume;
        //            utiliz.Prenume = account.Prenume;
        //            utiliz.Email = account.Email;
        //        }
        //    }

        //    return utiliz;
        //}
    }
}
