using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AmazingRating.Infrastructure.DataAccess.Repositories
{
    public class FilmRatingMemDbRepository : IFilmRatingRepository
    {
        private static readonly List<FilmRating> _set = new List<FilmRating>();

        public void Create(FilmRating entity)
        {
            _set.Add(entity);
        }

        public void Delete(Guid id)
        {
            _set.Remove(Read(id));
        }

        public IEnumerable<FilmRating> FindByProfile(Guid idprofile)
        {
            return ReadAll()
                .Where(cli => cli.profile.Id == idprofile);
        }

        public IEnumerable<FilmRating> FindByFilm(Guid idfilm)
        {
            return ReadAll()
                .Where(cli => cli.film.Id == idfilm);
        }

        public FilmRating Read(Guid id)
        {
            return _set.Find(e => e.Id == id);
        }

        public IEnumerable<FilmRating> ReadAll()
        {
            return _set;
        }

        public void Update(FilmRating entity)
        {
            Delete(entity.Id);
            Create(entity);
        }
    }
}
