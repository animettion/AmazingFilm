using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainService.Interfaces
{
    public interface ICommentService
    {
        void AddComment(Comment Comment);

        IEnumerable<Comment> GetAllComments();

        Comment GetCommentById(Guid id);


        IEnumerable<Comment> GetByFilm(Guid IdFilm);

    }
}
