using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Promotie
    {
        [Key]
        public int Id_promotie { get; set; }
        public DateTime Data_inceput { get; set; }
        public DateTime Data_sfarsit { get; set; }

        public List<Promotie_Produs> Promotie_Produs { get; set; }

    }
}
