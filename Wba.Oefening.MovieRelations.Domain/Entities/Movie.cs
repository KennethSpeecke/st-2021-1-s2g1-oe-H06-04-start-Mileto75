using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Wba.Oefening.RateAMovie.Domains.Entities;

namespace Wba.Oefening.RateAMovie.Domain.Entities
{
    public class Movie
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        //unshadowed foreign key for Company
        public long CompanyId { get; set; }

        public Company Company { get; set; }

        public ICollection<MovieActor> Cast { get; set; }

        public ICollection<MovieDirector> Directors { get; set; }
    }
}
