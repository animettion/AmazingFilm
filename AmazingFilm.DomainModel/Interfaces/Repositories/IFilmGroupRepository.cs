using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainModel.Interfaces.Repositories
{
    public interface IFilmGroupRepository //: IRepository<FilmGroup,Guid>
    {
        IEnumerable<FilmGroup> FindByName(string name);

        void Create(FilmGroup entity);
        FilmGroup Read(string name);
        IEnumerable<FilmGroup> ReadAll();
        void Update(FilmGroup entity);
        void Delete(string name);
    }
}
