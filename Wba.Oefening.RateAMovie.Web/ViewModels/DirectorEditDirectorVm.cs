using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wba.Oefening.RateAMovie.Web.ViewModels
{
    public class DirectorEditDirectorVm
    {
        //we hebben een property nodig voor de directorId
        //de id maken we hidden
        [HiddenInput]
        public long Id { get; set; }
        [Required(ErrorMessage = "Firstname verplicht!")]
        [Display(Name = "Firstname")]
        [MaxLength(150)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lastname verplicht!")]
        [Display(Name = "Lastname")]
        [MaxLength(150)]
        public string LastName { get; set; }
    }
}
