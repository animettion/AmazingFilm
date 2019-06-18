using AmazingFilm.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainModel.Interfaces.Repositories
{
    public interface IFilmRatingRepository : IRepository<FilmRating,Guid>
    {
        IEnumerable<FilmRating> FindByProfile(Guid idprofile);
        IEnumerable<FilmRating> FindByFilm(Guid idfilm);
    }
}
