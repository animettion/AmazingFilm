using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainService.Interfaces
{
    public interface IFilmService
    {
        void AddFilm(Film Film);

        void UpdateFilm(Film Film);

        IEnumerable<Film> GetAllFilms();

        Film GetFilmById(Guid id);

        void DeleteFilm(Guid id);

        IEnumerable<Film> SearchByName(string name);

    }
}
