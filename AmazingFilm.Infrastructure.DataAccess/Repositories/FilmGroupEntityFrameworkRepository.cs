using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using AmazingFilm.Infrastructure.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AmazingFilmGroup.Infrastructure.DataAccess.Repositories
{
    public class FilmGroupEntityFrameworkRepository : IFilmGroupRepository
    {

        private readonly AmazingFilmContext _db;

        public FilmGroupEntityFrameworkRepository(AmazingFilmContext db)
        {
            _db = db;
        }

        public void Create(FilmGroup entity)
        {
            _db.FilmGroups.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _db.Remove(Read(id));
            _db.SaveChanges();
        }

        public IEnumerable<FilmGroup> FindByName(string name)
        {
            //_db.FilmGroups.FromSql($"Select * from FilmGroups where Name LIKE %{name}%");

            return _db.FilmGroups
                .Where(cli => EF.Functions
                .Like(cli.Name, $"%{name}%"));
        }

        public FilmGroup Read(Guid id)
        {
            return _db.FilmGroups.Find(id);
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
