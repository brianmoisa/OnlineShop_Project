using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.ViewModels
{
    public class LogareViewModel
    {
        [Required(ErrorMessage = "Introduceti adresa de email")]
        [EmailAddress(ErrorMessage = "Introduceti o adresa de email valida")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Introduceti parola")]
        [DataType(DataType.Password)]
        public string Parola { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
