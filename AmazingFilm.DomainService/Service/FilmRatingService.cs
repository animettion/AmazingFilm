
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainService.Interfaces;

namespace AmazingFilmRating.DomainService
{
    public class FilmRatingService : IFilmRatingService
    {
        private IFilmRatingRepository _FilmRatingRepository;

        public FilmRatingService(IFilmRatingRepository FilmRatingRepository)
        {
            _FilmRatingRepository = FilmRatingRepository;
        }

        public void AddFilmRating(FilmRating FilmRating)
        {
            var rating = ExistsFilmPrfile(FilmRating.FilmId, FilmRating.ProfileId);
            if (rating == null)
            {
                _FilmRatingRepository.Create(FilmRating);
            }
            else
            {
                rating.liked = FilmRating.liked;
                _FilmRatingRepository.Update(rating);
            }
        }

        public IEnumerable<FilmRating> GetAllFilmRatings()
        {
            return _FilmRatingRepository.ReadAll();
        }

        public FilmRating GetFilmRatingById(Guid id)
        {
            return _FilmRatingRepository.Read(id);
        }

        public IEnumerable<FilmRating> GetByFilm(Guid idFilm)
        {
            var aux = _FilmRatingRepository.ReadAll()
                .Where(c => c.FilmId == idFilm);


            return aux;
        }

        public FilmRating ExistsFilmPrfile(Guid idFilm, Guid IdProfile)
        {
            var aux = _FilmRatingRepository.ReadAll()
                .Where(c => c.FilmId == idFilm && c.ProfileId == IdProfile).FirstOrDefault();
            return aux;
        }
    }
}
