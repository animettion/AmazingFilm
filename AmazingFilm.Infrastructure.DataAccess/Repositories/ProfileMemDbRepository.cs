using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AmazingFilm.Infrastructure.DataAccess.Repositories
{
    public class ProfileMemDbRepository : IProfileRepository
    {
        private static readonly List<Profile> _set = new List<Profile>();

        public void Create(Profile entity)
        {
            _set.Add(entity);
        }

        public void Delete(Guid id)
        {
            _set.Remove(Read(id));
        }

        public IEnumerable<Profile> FindByName(string name)
        {
            return ReadAll()
                .Where(cli => cli.Name.ToLower()
                    .Contains(name.ToLower()));
        }

        public Profile Read(Guid id)
        {
            return _set.Find(e => e.Id == id);
        }

        public IEnumerable<Profile> ReadAll()
        {
            return _set;
        }

        public void Update(Profile entity)
        {
            Delete(entity.Id);
            Create(entity);
        }
    }
}
