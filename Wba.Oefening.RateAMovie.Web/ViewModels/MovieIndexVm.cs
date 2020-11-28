using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.Oefening.RateAMovie.Domain.Entities;

namespace Wba.Oefening.RateAMovie.Web.ViewModels
{
    public class MovieIndexVm
    {
        public IEnumerable<Movie> Movies { get; set; }
    }
}
