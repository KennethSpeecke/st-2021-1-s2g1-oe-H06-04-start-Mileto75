using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wba.Oefening.RateAMovie.Domain.Entities
{
    public class MovieDirector
    {
        //unshadowed foreign Key for Movie relationship
        public long MovieId { get; set; }

        //unshadowed foreign Key for Director relationship
        public long DirectorId { get; set; }

        public Movie Movie { get; set; }

        public Director Director { get; set; }
    }
}
