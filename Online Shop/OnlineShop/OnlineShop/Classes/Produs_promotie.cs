using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Classes
{
    public class Produs_promotie
    {
        public int Id_Produs { get; set; }
        public string Nume { get; set; }
        public string Descriere { get; set; }
        public float? Pret { get; set; }
        public float? Cantitate { get; set; }
        public int? Procentaj { get; set; }
        public float? Pret_redus { get; set; }
        public string Poza { get; set; }

    }
}
