using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using AmazingFilm.Infrastructure.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AmazingFilm.Infrastructure.DataAccess.Factories;
using AmazingFilm.DomainModel.ValueObjects;

namespace AmazingFilm.Infrastructure.DataAccess.Repositories
{
    public class FilmGroupEntityFrameworkRepository : IFilmGroupRepository
    {

        private readonly AmazingFilmContext _db;

        public FilmGroupEntityFrameworkRepository()
        {
            _db = new AmazingFilmContextFactory().CreateDbContext(null);
        }

        public void Create(FilmGroup entity)
        {
            _db.FilmGroups.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(string name)
        {
            _db.Remove(Read(name));
            _db.SaveChanges();
        }

        public IEnumerable<FilmGroup> FindByName(string name)
        {
            //_db.FilmGroups.FromSql($"Select * from FilmGroups where Name LIKE %{name}%");

            return _db.FilmGroups
                .Where(cli => EF.Functions
                .Like(cli.Name, $"%{name}%"));
        }

        public FilmGroup Read(string name)
        {
            return _db.FilmGroups.Find(name);
        }

        public IEnumerable<FilmGroup> ReadAll()
        {
            return _db.FilmGroups;
        }

        public void Update(FilmGroup entity)
        {
            _db.FilmGroups.Update(entity);
            _db.SaveChanges();
        }
    }
}
