using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Promotie_Produs
    {
        [Key]
        public int Id_Produs { get; set; }
        [Key]
        public int Id_promotie { get; set; }
        public int? Procentaj { get; set; }

        public Produs Produs { get; set; }
        public Promotie Promotie { get; set; }
    }
}
