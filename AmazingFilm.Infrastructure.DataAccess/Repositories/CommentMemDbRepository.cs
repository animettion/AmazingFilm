using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AmazingFilm.Infrastructure.DataAccess.Repositories
{
    public class CommentMemDbRepository : ICommentRepository
    {
        private static readonly List<Comment> _set = new List<Comment>();

        public void Create(Comment entity)
        {
            _set.Add(entity);
        }

        public void Delete(Guid id)
        {
            _set.Remove(Read(id));
        }

        public IEnumerable<Comment> GetByFilm(Guid idfilme)
        {
            return ReadAll()
                .Where(cli => cli.FilmId == idfilme);
        }

       

        public Comment Read(Guid id)
        {
            return _set.Find(e => e.Id == id);
        }

        public IEnumerable<Comment> ReadAll()
        {
            return _set;
        }

        public void Update(Comment entity)
        {
            Delete(entity.Id);
            Create(entity);
        }
    }
}
