using AmazingFilm.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainModel.Interfaces.Repositories
{
    public interface IFilmGroupRepository : IRepository<FilmGroup,Guid>
    {
        IEnumerable<FilmGroup> FindByName(string name);
    }
}
