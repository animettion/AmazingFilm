using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using AmazingFilm.Infrastructure.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AmazingFilm.Infrastructure.DataAccess.Factories;

namespace AmazingFilm.Infrastructure.DataAccess.Repositories
{
    public class ProfileEntityFrameworkRepository : IProfileRepository
    {

        private readonly AmazingFilmContext _db;

        public ProfileEntityFrameworkRepository()
        {
            _db = new AmazingFilmContextFactory().CreateDbContext(null);
        }

        public void Create(Profile entity)
        {
            _db.Profiles.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _db.Remove(Read(id));
            _db.SaveChanges();
        }


        public Profile Read(Guid id)
        {
            return _db.Profiles.Find(id);
        }

        public IEnumerable<Profile> ReadAll()
        {
            return _db.Profiles;
        }

        public void Update(Profile entity)
        {
            _db.Profiles.Update(entity);
            _db.SaveChanges();
        }
    }
}
