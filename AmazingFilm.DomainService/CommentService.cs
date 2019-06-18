
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using AmazingFilm.DomainModel.Entities;

namespace AmazingComment.DomainService
{
    public class CommentService
    {
        private ICommentRepository _CommentRepository;

        public CommentService(ICommentRepository CommentRepository)
        {
            _CommentRepository = CommentRepository;
        }

        public void AddComment(Comment Comment)
        {
            _CommentRepository.Create(Comment);
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _CommentRepository.ReadAll();
        }

        public Comment GetCommentById(Guid id)
        {
            return _CommentRepository.Read(id);
        }

        public IEnumerable<Comment> SearchByFilm(Guid idFilm)
        {
            return _CommentRepository.ReadAll()
                .Where(c => c.Film.Id == idFilm);
        }
    }
}
