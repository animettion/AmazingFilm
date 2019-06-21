using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
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

        FilmGroup GetFilmGroupById(Guid id);

        void DeleteFilmGroup(Guid id);

        IEnumerable<FilmGroup> SearchByName(string name);

    }
}
