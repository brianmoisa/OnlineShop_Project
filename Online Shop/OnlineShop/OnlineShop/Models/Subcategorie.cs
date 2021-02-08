using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Subcategorie
    {
        [Key]

        public string Nume_subcateg { get; set; }     
        public string Descriere { get; set; }

        public string Nume_categorie { get; set; }
        public Categorie Categorie { get; set; }

        public List<Produs> Subgategorii { get; set; }
    }
}
