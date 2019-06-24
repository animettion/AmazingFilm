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
    public class FilmRatingEntityFrameworkRepository : IFilmRatingRepository
    {

        private readonly AmazingFilmContext _db;

        public FilmRatingEntityFrameworkRepository()
        {
            _db = new AmazingFilmContextFactory().CreateDbContext(null);
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

        public IEnumerable<FilmRating> GetByFilm(Guid Id)
        {
            //_db.FilmRatings.FromSql($"Select * from FilmRatings where Name LIKE %{name}%");

            var aux = _db.FilmRatings
                .Where(cli => cli.FilmId == Id)
                .Select(m => new FilmRating
                {
                    FilmId = m.FilmId,
                    ProfileId = m.ProfileId,
                    profile = _db.Profiles.Where(p => p.Id == m.ProfileId).FirstOrDefault(),
                    PublishDateTime = m.PublishDateTime,
                    liked = m.liked,
                    Id = Id
                });

            return aux;
        }

        public FilmRating Read(Guid id)
        {
            return _db.FilmRatings.Find(id);
        }

        public IEnumerable<FilmRating> ReadAll()
        {
            var aux = _db.FilmRatings
               .Select(m => new FilmRating
               {
                   FilmId = m.FilmId,
                   ProfileId = m.ProfileId,
                   profile = _db.Profiles.Where(p => p.Id == m.ProfileId).FirstOrDefault(),
                   PublishDateTime = m.PublishDateTime,
                   liked = m.liked,
                   Id = m.Id
               });

            return aux;
        }


        public void Update(FilmRating entity)
        {
            _db.FilmRatings.Update(entity);
            _db.SaveChanges();
        }
    }
}
