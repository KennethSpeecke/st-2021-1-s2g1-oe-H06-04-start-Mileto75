using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wba.Oefening.RateAMovie.Web.ViewModels
{
    public class HomeAddMovieVm
    {
        [Required(ErrorMessage ="Titel verplicht!")]
        [Display(Name ="Titel")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Releasedatum verplicht!")]
        [Display(Name = "Releasedatum")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate{ get; set; }
        [Display(Name ="Company")]
        public int CompanyId { get; set; }
        public List<SelectListItem> Companies { get; set; }
        [Display(Name = "Director")]
        public int DirectorId { get; set; }
        public List<SelectListItem> Directors { get; set; }
    }
}
