using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.ViewModels
{
    public class DetaliiUtilizatorViewModel:InregistrareViewModel
    {
        [Required(ErrorMessage = "Introduceti parola")]
        [DataType(DataType.Password)]
        public string ParolaVeche { get; set; }

        [Required(ErrorMessage = "Introduceti adresa de email")]
        [EmailAddress(ErrorMessage = "Introduceti o adresa de email valida")]
        public string EmailNou { get; set; }
    }
}
