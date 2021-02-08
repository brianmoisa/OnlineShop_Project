using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Utilizator
    {
        [Key]
        public int Utilizator_Id { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Telefon { get; set; }
        public DateTime Ultima_logare { get; set; }
        public string Cont_activ { get; set; }
    }
}
