using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.Infrastructure.DataAccess.Contexts
{
    public class AmazingFilmContext : DbContext
    {
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Film> Films { get; set; }
        public virtual DbSet<FilmGroup> FilmGroups { get; set; }
        public virtual DbSet<FilmRating> FilmRatings { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public AmazingFilmContext(DbContextOptions<AmazingFilmContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public AmazingFilmContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(Properties.Resources.
                ResourceManager.GetString("DbConnectionString"));
        }
    }
}
