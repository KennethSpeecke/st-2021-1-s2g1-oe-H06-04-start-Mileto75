using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.Oefening.RateAMovie.Domain.Entities;

namespace Wba.Oefening.RateAMovie.Domains.Entities
{
    public class Company
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
