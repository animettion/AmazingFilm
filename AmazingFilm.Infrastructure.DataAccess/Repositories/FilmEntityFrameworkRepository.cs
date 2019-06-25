using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using AmazingFilm.Infrastructure.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AmazingFilm.Infrastructure.DataAccess.Factories;

namespace AmazingFilm.Infrastructure.DataAccess.Repositories
{
    public class FilmEntityFrameworkRepository : IFilmRepository
    {

        private readonly AmazingFilmContext _db;

        public FilmEntityFrameworkRepository()
        {
            _db = new AmazingFilmContextFactory().CreateDbContext(null);
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

            CommentEntityFrameworkRepository commtFramework = new CommentEntityFrameworkRepository();
            FilmRatingEntityFrameworkRepository ratingFramework = new FilmRatingEntityFrameworkRepository();
            var aux = _db.Films.Find(id);
            aux.Comments = commtFramework.GetByFilm(id).ToList();
            aux.FilmRatings = ratingFramework.GetByFilm(id).ToList();
            return aux;
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
