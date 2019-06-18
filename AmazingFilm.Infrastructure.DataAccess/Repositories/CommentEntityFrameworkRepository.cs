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
    public class CommentEntityFrameworkRepository : ICommentRepository
    {

        private readonly AmazingFilmContext _db;

        public CommentEntityFrameworkRepository(AmazingFilmContext db)
        {
            _db = db;
        }

        public void Create(Comment entity)
        {
            _db.Comments.Add(entity);
            _db.SaveChanges();
        }

        public IEnumerable<Comment> SearchByFilm(Guid idfilme)
        {
            return ReadAll()
                .Where(cli => cli.Film.Id == idfilme);
        }

        public void Delete(Guid id)
        {
            _db.Remove(Read(id));
            _db.SaveChanges();
        }


        public IEnumerable<Comment> FindByFilm(Guid idfilme)
        {
            //_db.Comments.FromSql($"Select * from Comments where Name LIKE %{name}%");

            return _db.Comments
                .Where(cli => cli.Film.Id == idfilme);
        }

        public Comment Read(Guid id)
        {
            return _db.Comments.Find(id);
        }

        public IEnumerable<Comment> ReadAll()
        {
            return _db.Comments;
        }

        public void Update(Comment entity)
        {
            _db.Comments.Update(entity);
            _db.SaveChanges();
        }
    }
}
