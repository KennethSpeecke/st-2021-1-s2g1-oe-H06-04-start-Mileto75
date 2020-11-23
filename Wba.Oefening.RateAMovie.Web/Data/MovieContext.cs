using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.Oefening.RateAMovie.Domain.Entities;
using Wba.Oefening.RateAMovie.Domains.Entities;

namespace Wba.Oefening.RateAMovie.Web.Data
{
    public class MovieContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configure the User Entity
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<User>()
                .Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.FirstName)
                .HasMaxLength(100);

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)
                .HasMaxLength(100);

            //Configure the Movie Entity
            modelBuilder.Entity<Movie>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Movie>()
                .Property(u => u.Id)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<Movie>()
                .Property(u => u.Title)
                .IsRequired()
                .HasMaxLength(200);

            //Configure the Actor Entity
            modelBuilder.Entity<Actor>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Actor>()
                .Property(u => u.Id)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<Actor>()
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Actor>()
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            //Configure the Director Entity
            modelBuilder.Entity<Director>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Director>()
                .Property(u => u.Id)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<Director>()
                .Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Director>()
                .Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            //Configure the Company Entity
            modelBuilder.Entity<Company>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Company>()
                .Property(u => u.Id)
                .UseSqlServerIdentityColumn();

            modelBuilder.Entity<Company>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(200);


            //Configure the Rating Entity
            modelBuilder.Entity<Rating>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Rating>()
                .Property(u => u.Id)
                .UseSqlServerIdentityColumn();

            //Configure the MovieActor joining entity
            modelBuilder.Entity<MovieActor>()
                .HasKey(u => new { u.MovieId, u.ActorId });

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Actor)
                .WithMany(actor => actor.MovieAppearances)
                .HasForeignKey(md => md.ActorId); //overbodig want naamgeving van ActorId is al per conventie

            modelBuilder.Entity<MovieActor>()
                .HasOne(ma => ma.Movie)
                .WithMany(movie => movie.Cast)
                .HasForeignKey(ma => ma.MovieId); //overbodig want naamgeving van MovieId is al per conventie

            //Configure the MovieDirector joining entity
            modelBuilder.Entity<MovieDirector>()
                .HasKey(u => new { u.MovieId, u.DirectorId });

            modelBuilder.Entity<MovieDirector>()
                .HasOne(md => md.Director)
                .WithMany(director => director.DirectedMovies)
                .HasForeignKey(md => md.DirectorId); //overbodig want naamgeving van DirectorId is al per conventie

            modelBuilder.Entity<MovieDirector>()
                .HasOne(md => md.Movie)
                .WithMany(movie => movie.Directors)
                .HasForeignKey(md => md.MovieId); //overbodig want naamgeving van MovieId is al per conventie

            
            



            //finally, seed this db
            Seeder.SeedData(modelBuilder);
        }

    }
}
