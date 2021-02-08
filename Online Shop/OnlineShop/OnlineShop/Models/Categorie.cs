using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Categorie
    {
        [Key]
        public string Nume_categorie { get; set; }
        public string Descriere { get; set; }

        public List<Subcategorie> Subgategorii { get; set; }
    }
}
