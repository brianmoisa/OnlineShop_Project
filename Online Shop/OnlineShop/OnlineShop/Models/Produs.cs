using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Produs
    {
        [Key]
        public int Id_Produs { get; set; }
        public string Nume { get; set; }
        public string Descriere { get; set; }
        public float? Pret { get; set; }
        public float? Cantitate { get; set; }
        public DateTime DataAdaugare { get; set; }
        public string Poza { get; set; }
        public string DetaliiTehnice { get; set; }
        public string Brand { get; set; }

        public string Nume_subcateg { get; set; }
        public Subcategorie Subcategorie { get; set; }

        public List<Promotie_Produs> Promotie_Produs { get; set; }

        public static implicit operator Produs(List<object> v)
        {
            throw new NotImplementedException();
        }
    }
}
