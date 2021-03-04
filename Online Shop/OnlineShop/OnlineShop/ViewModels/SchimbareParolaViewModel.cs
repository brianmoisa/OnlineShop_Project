using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.ViewModels
{
    public class SchimbareParolaViewModel
    {
        [Required(ErrorMessage = "Introduceti parola curenta")]
        [DataType(DataType.Password)]
        public string ParolaVeche { get; set; }

        [Required(ErrorMessage = "Introduceti parola noua")]
        [DataType(DataType.Password)]
        public string ParolaNoua { get; set; }

        [Required(ErrorMessage = "Confirmati parola noua")]
        [DataType(DataType.Password)]
        [Compare("ParolaNoua", ErrorMessage = "Parolele trebuie sa coincida!")]
        public string ConfirmParolaNoua { get; set; }
    }
}
