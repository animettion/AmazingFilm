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
