using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.Oefening.RateAMovie.Web.Helpers;

namespace Wba.Oefening.RateAMovie.Web.ViewModels
{
    public class MovieAddDirectorsVm
    {
        public long? MovieId { get; set; }
        public string Title { get; set; }
        public List<DirectorCheckBox> Directors { get; set; }
        = new List<DirectorCheckBox>();
    }
}
