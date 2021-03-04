using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShop.Data;
using OnlineShop.Models;
using OnlineShop.ViewModels;

namespace OnlineShop.Repository
{
    public class ProduseCategoriiRepository : IProduseCategoriiRepository
    {
        
        private readonly ApplicationDBContext context;
        public ProduseCategoriiRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public Produs GetProdus(int id)
        {
            Produs prod = new Produs();
            prod = context.Produse.FirstOrDefault(x => x.Id_Produs == id);

            return prod;
        }

        public IEnumerable<Produs> GetProductsByCategory(string idCateg)
        {
            IEnumerable<Produs> produs = null;
            if (context.Categorii.Any(x => x.Nume_categorie == idCateg))
            {
                produs = from a in context.Categorii
                              join b in context.Subcategorii on a.Nume_categorie equals b.Nume_categorie
                              join c in context.Produse on b.Nume_subcateg equals c.Nume_subcateg
                              where a.Nume_categorie == idCateg
                              select new Produs()
                              {
                                  Id_Produs = c.Id_Produs,
                                  Nume = c.Nume,
                                  Descriere = c.Descriere,
                                  Pret = c.Pret,
                                  Poza = c.Poza,
                                  Nume_subcateg = c.Nume_subcateg
                              };
            }

            return produs;
        }

        public IEnumerable<Subcategorie> GetSubcategByCategory(string idCateg)
        {
            IEnumerable<Subcategorie> subcategorii = null;
            if (context.Categorii.Any(x => x.Nume_categorie == idCateg))
            {
                subcategorii = from a in context.Subcategorii
                                where a.Nume_categorie == idCateg
                                select new Subcategorie
                                {
                                    Nume_subcateg = a.Nume_subcateg,
                                    Descriere = a.Descriere
                                };
            }

            return subcategorii;
        }


        //ProduseCategoriiViewModel IProduseCategoriiRepository.GetProduseCategorii(string idCateg)
        //{
        //    ProduseCategoriiViewModel prod = new ProduseCategoriiViewModel();

        //    if (context.Categorii.Any(x => x.Nume_categorie == idCateg))
        //    {
        //        prod.Produse = from a in context.Categorii
        //                       join b in context.Subcategorii on a.Nume_categorie equals b.Nume_categorie
        //                       join c in context.Produse on b.Nume_subcateg equals c.Nume_subcateg
        //                       where a.Nume_categorie == idCateg
        //                       select new Produs()
        //                       {
        //                           Id_Produs = c.Id_Produs,
        //                           Nume = c.Nume,
        //                           Descriere = c.Descriere,
        //                           Pret = c.Pret,
        //                           Poza = c.Poza,
        //                           Nume_subcateg = c.Nume_subcateg
        //                       };

        //        prod.Subcategorie = from a in context.Subcategorii
        //                            where a.Nume_categorie == idCateg
        //                            select new Subcategorie
        //                            {
        //                                Nume_subcateg = a.Nume_subcateg,
        //                                Descriere = a.Descriere
        //                            };

        //        prod.titluPagina = idCateg;


        //    }

        //    return prod;
        //}
    }
}
