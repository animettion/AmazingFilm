using AmazingFilm.DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.Infrastructure.DataAccess.Contexts
{
    public class AmazingFilmContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmGroup> FilmGroups { get; set; }

        public DbSet<FilmRating> FilmRatings { get; set; }
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
