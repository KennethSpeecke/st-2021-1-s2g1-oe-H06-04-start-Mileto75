using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wba.Oefening.RateAMovie.Web.ViewModels
{
    public class CompanyAddCompanyVm
    {
        [Required]
        [Display(Name ="Company name")]
        [MaxLength(150)]
        public string Name { get; set; }
    }
}
