using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.ViewModels
{
    public class DetaliiUtilizatorViewModel
    {
        public string Email { get; set; }

        [DataType(DataType.Text)]
        public string Nume { get; set; }

        [DataType(DataType.Text)]
        public string Prenume { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }
    }
}
