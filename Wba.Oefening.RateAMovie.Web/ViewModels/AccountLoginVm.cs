using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wba.Oefening.RateAMovie.Web.ViewModels
{
    public class AccountLoginVm
    {
        [Required(ErrorMessage = "Username verplicht")]
        [EmailAddress(ErrorMessage = "Geef geldig emailadres in!")]
        [Display(Name = "Gebruikersnaam")]
        public string userName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Paswoord verplicht")]
        [Display(Name = "Paswoord")]
        public string Password { get; set; }
    }
}
