﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.Oefening.RateAMovie.Domain.Entities;
using Wba.Oefening.RateAMovie.Domains.Entities;

namespace Wba.Oefening.RateAMovie.Web.Data
{
    public class Seeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {

            // add some companies
            modelBuilder.Entity<Company>().HasData(
                new Company { Id = 1, Name = "The Wachowski Brothers" },
                new Company { Id = 20, Name = "Newline Cinema" }
            );

            // add some movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, 
                            CompanyId = 1,  //The Wachowski Brothers
                            Title = "The Matrix", ReleaseDate = new DateTime(1999, 7, 7) },
                new Movie { Id = 2, 
                            CompanyId = 20, //Newline Cinema
                            Title = "The Fellowship of the Ring", ReleaseDate = new DateTime(2001, 12, 19) }
            );

            // add some directors
            modelBuilder.Entity<Director>().HasData(
                new Director { Id = 1, FirstName = "Lana", LastName = "Wachowski" },
                new Director { Id = 2, FirstName = "Lilly", LastName = "Wachowski" },
                new Director { Id = 3, FirstName = "Peter", LastName = "Jackson" }
            );

            // add some users
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "siegfried.derdeyn", FirstName = "Siegfried", LastName = "Derdeyn" },
                new User { Id = 2, Username = "joachim.francois", FirstName = "Joachim", LastName = "François" }
            );

            // add ratings from users for some movies
            modelBuilder.Entity<Rating>().HasData(
                //siegfried's (reviewerId 1) rating for The Matrix (ratedmovieId 1)
                new Rating { Id = 100, ReviewerId = 1, RatedMovieId = 1, Score=3, Review = "I think this movie is ok!" },
                //siegfried's (reviewerId 1) rating for The Fellowship of the Ring (ratedmovieId 2)
                new Rating { Id = 101, ReviewerId = 1, RatedMovieId = 2, Score = 4, Review = "I think this movie is really nice!" },
                //joachim's (reviewerId 2) rating for The Matrix (ratedmovieId 1)
                new Rating { Id = 102, ReviewerId = 2, RatedMovieId = 1, Score = 4 }
            );

            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, FirstName = "Keanu", LastName = "Reeves" },
                new Actor { Id = 2, FirstName = "Laurence", LastName = "Fishburne" },
                new Actor { Id = 3, FirstName = "Carrie-Anne", LastName = "Moss" },
                new Actor { Id = 4, FirstName = "Sean", LastName = "Bean" }
            );

            //link actors to movies
            modelBuilder.Entity<MovieActor>().HasData(
                //Keanu (1) stars in The Matrix (1)
                new MovieActor { ActorId = 1, MovieId = 1 },
                //Laurence (2) stars in The Matrix (1)
                new MovieActor { ActorId = 2, MovieId = 1 },
                //Carrie-Anne (3) stars in The Matrix (1)
                new MovieActor { ActorId = 3, MovieId = 1 },
                //Sean (4) stars in The Fellowship of the Ring (2)
                new MovieActor { ActorId = 4, MovieId = 2 }
            );


            //link directors to movies
            modelBuilder.Entity<MovieDirector>().HasData(
                //Lana (1) & Lilly (2) directed The Matrix (1)
                new MovieDirector { DirectorId = 1, MovieId = 1 },
                new MovieDirector { DirectorId = 2, MovieId = 1 },

                //Peter (3) directed  The Fellowship of the Ring (2)
                new MovieDirector { DirectorId = 3, MovieId = 2 }
            );
        }
    }
}
