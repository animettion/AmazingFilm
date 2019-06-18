using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AmazingFilm.Infrastructure.DataAccess.Repositories
{
    public class FilmMemDbRepository : IFilmRepository
    {
        private static readonly List<Film> _set = new List<Film>();

        public void Create(Film entity)
        {
            _set.Add(entity);
        }

        public void Delete(Guid id)
        {
            _set.Remove(Read(id));
        }

        public IEnumerable<Film> FindByName(string name)
        {
            return ReadAll()
                .Where(cli => cli.Name.ToLower()
                    .Contains(name.ToLower()));
        }

        public Film Read(Guid id)
        {
            return _set.Find(e => e.Id == id);
        }

        public IEnumerable<Film> ReadAll()
        {
            return _set;
        }

        public void Update(Film entity)
        {
            Delete(entity.Id);
            Create(entity);
        }
    }
}
