
using AmazingFilm.Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.Infrastructure.DataAccess.Factories
{
    public class AmazingFilmContextFactory : IDesignTimeDbContextFactory<AmazingFilmContext>
    {

        public AmazingFilmContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AmazingFilmContext>();

             optionsBuilder.UseSqlServer(Properties.Resources.
                ResourceManager.GetString("DbConnectionString"));


            return new AmazingFilmContext(optionsBuilder.Options);
        }

    }
}
