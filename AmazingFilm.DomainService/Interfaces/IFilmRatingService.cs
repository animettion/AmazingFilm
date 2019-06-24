using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainService.Interfaces
{
    public interface IFilmRatingService
    {
        void AddFilmRating(FilmRating Comment);

        IEnumerable<FilmRating> GetAllFilmRatings();

        FilmRating GetFilmRatingById(Guid id);


        IEnumerable<FilmRating> GetByFilm(Guid IdFilm);

    }
}
