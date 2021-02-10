using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.ViewModels
{
    public class InregistrareViewModel
    {
        [Required(ErrorMessage = "Introduceti adresa de email")]
        [EmailAddress(ErrorMessage ="Introduceti o adresa de email valida")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Introduceti parola")]
        [DataType(DataType.Password)]
        public string Parola { get; set; }

        [Required(ErrorMessage = "Confirmati parola")]
        [DataType(DataType.Password)]
        [Compare("Parola", ErrorMessage ="Parolele trebuie sa coincida!")]
        public string ConfirmParola { get; set; }

       
        [Required(ErrorMessage ="Introduceti numele")]
        [DataType(DataType.Text)]
        public string Nume { get; set; }

        [Required(ErrorMessage = "Introduceti prenumele")]
        [DataType(DataType.Text)]
        public string Prenume { get; set; }

        [Required(ErrorMessage = "Introduceti numarul de telefon")]
        [MaxLength(18)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Numarul de telefon introdus nu este valid")]
        public string Telefon { get; set; }

    }
}
