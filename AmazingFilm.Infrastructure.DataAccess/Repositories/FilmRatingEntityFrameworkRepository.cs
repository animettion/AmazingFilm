using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using AmazingFilm.Infrastructure.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AmazingFilmRating.Infrastructure.DataAccess.Repositories
{
    public class FilmRatingEntityFrameworkRepository : IFilmRatingRepository
    {

        private readonly AmazingFilmContext _db;

        public FilmRatingEntityFrameworkRepository(AmazingFilmContext db)
        {
            _db = db;
        }

        public void Create(FilmRating entity)
        {
            _db.FilmRatings.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _db.Remove(Read(id));
            _db.SaveChanges();
        }

        public IEnumerable<FilmRating> FindByProfile(Guid idprofile)
        {
            //_db.FilmRatings.FromSql($"Select * from FilmRatings where Name LIKE %{name}%");

            return _db.FilmRatings
                .Where(cli => cli.profile.Id == idprofile);
        }

        public IEnumerable<FilmRating> FindByFilm(Guid idfilme)
        {
            //_db.FilmRatings.FromSql($"Select * from FilmRatings where Name LIKE %{name}%");

            return _db.FilmRatings
                .Where(cli => cli.film.Id == idfilme);
        }

        public FilmRating Read(Guid id)
        {
            return _db.FilmRatings.Find(id);
        }

        public IEnumerable<FilmRating> ReadAll()
        {
            return _db.FilmRatings;
        }

        public void Update(FilmRating entity)
        {
            _db.FilmRatings.Update(entity);
            _db.SaveChanges();
        }
    }
}
