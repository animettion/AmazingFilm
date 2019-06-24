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
    public class CommentEntityFrameworkRepository : ICommentRepository
    {

        private readonly AmazingFilmContext _db;

        public CommentEntityFrameworkRepository()
        {
            _db = new AmazingFilmContextFactory().CreateDbContext(null);
        }

        public void Create(Comment entity)
        {
            _db.Comments.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _db.Remove(Read(id));
            _db.SaveChanges();
        }

        public IEnumerable<Comment> GetByFilm(Guid Id)
        {
            //_db.Comments.FromSql($"Select * from Comments where Name LIKE %{name}%");
          
            var aux =  _db.Comments
                .Where(cli => cli.FilmId == Id)
                .Select(m => new Comment
                {
                    FilmId = m.FilmId,
                    ProfileId = m.ProfileId,
                    profile = _db.Profiles.Where(p=>p.Id == m.ProfileId).FirstOrDefault(),
                    PublishDateTime = m.PublishDateTime,
                    Text = m.Text,
                    Id = Id
                }).OrderByDescending(p=>p.PublishDateTime);

            return aux;
        }

        public Comment Read(Guid id)
        {
            return _db.Comments.Find(id);
        }

        public IEnumerable<Comment> ReadAll()
        {
            var aux = _db.Comments
               .Select(m => new Comment
               {
                   FilmId = m.FilmId,
                   ProfileId = m.ProfileId,
                   profile = _db.Profiles.Where(p => p.Id == m.ProfileId).FirstOrDefault(),
                   PublishDateTime = m.PublishDateTime,
                   Text = m.Text,
                   Id = m.Id
               });

            return aux;
        }
    

        public void Update(Comment entity)
        {
            _db.Comments.Update(entity);
            _db.SaveChanges();
        }
    }
}
