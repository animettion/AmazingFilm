using AmazingFilm.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainModel.Interfaces.Repositories
{
    public interface IFilmRepository : IRepository<Film,Guid>
    {
        IEnumerable<Film> FindByName(string name);
    }
}
