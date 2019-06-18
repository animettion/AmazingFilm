using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using AmazingFilm.Infrastructure.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AmazingFilm.Infrastructure.DataAccess.Repositories
{
    public class FilmEntityFrameworkRepository : IFilmRepository
    {

        private readonly AmazingFilmContext _db;

        public FilmEntityFrameworkRepository(AmazingFilmContext db)
        {
            _db = db;
        }

        public void Create(Film entity)
        {
            _db.Films.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _db.Remove(Read(id));
            _db.SaveChanges();
        }

        public IEnumerable<Film> FindByName(string name)
        {
            //_db.Films.FromSql($"Select * from Films where Name LIKE %{name}%");

            return _db.Films
                .Where(cli => EF.Functions
                .Like(cli.Name, $"%{name}%"));
        }

        public Film Read(Guid id)
        {
            return _db.Films.Find(id);
        }

        public IEnumerable<Film> ReadAll()
        {
            return _db.Films;
        }

        public void Update(Film entity)
        {
            _db.Films.Update(entity);
            _db.SaveChanges();
        }
    }
}
