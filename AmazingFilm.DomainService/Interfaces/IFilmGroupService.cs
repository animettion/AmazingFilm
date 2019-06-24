using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using AmazingFilm.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainService.Interfaces
{
    public interface IFilmGroupService
    {
        void AddFilmGroup(FilmGroup FilmGroup);

        void UpdateFilmGroup(FilmGroup FilmGroup);

        IEnumerable<FilmGroup> GetAllFilmGroups();

        FilmGroup GetFilmGroupByName(string name);

        void DeleteFilmGroup(string name);

        IEnumerable<FilmGroup> SearchByName(string name);

    }
}
