using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wba.Oefening.RateAMovie.Domain.Entities
{
    public class MovieActor
    {
        //unshadowed foreign Key for Movie relationship
        public long MovieId { get; set; }

        //unshadowed foreign Key for Actor relationship
        public long ActorId { get; set; }

        public Movie Movie { get; set; }

        public Actor Actor { get; set; }

    }
}
