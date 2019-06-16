using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using AmazingFilm.Infrastructure.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AmazingFilm.Infrastructure.DataAccess.Repositories
{
    public class ProfileEntityFrameworkRepository : IProfileRepository
    {

        private readonly AmazingFilmContext _db;
        
        public ProfileEntityFrameworkRepository(AmazingFilmContext db)
        {
            _db = db;
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

        public IEnumerable<Profile> FindByName(string name)
        {
            //_db.Profiles.FromSql($"Select * from Profiles where Name LIKE %{name}%");

            return _db.Profiles
                .Where(cli => EF.Functions
                .Like(cli.Name, $"%{name}%"));
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
