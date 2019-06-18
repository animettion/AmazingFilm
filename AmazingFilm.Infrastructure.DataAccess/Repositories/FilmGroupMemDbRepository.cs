using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AmazingGroup.Infrastructure.DataAccess.Repositories
{
    public class GroupMemDbRepository : IFilmGroupRepository
    {
        private static readonly List<FilmGroup> _set = new List<FilmGroup>();

        public void Create(FilmGroup entity)
        {
            _set.Add(entity);
        }

        public void Delete(Guid id)
        {
            _set.Remove(Read(id));
        }

        public IEnumerable<FilmGroup> FindByName(string name)
        {
            return ReadAll()
                .Where(cli => cli.Name.ToLower()
                    .Contains(name.ToLower()));
        }

        public FilmGroup Read(Guid id)
        {
            return _set.Find(e => e.Id == id);
        }

        public IEnumerable<FilmGroup> ReadAll()
        {
            return _set;
        }

        public void Update(FilmGroup entity)
        {
            Delete(entity.Id);
            Create(entity);
        }
    }
}
