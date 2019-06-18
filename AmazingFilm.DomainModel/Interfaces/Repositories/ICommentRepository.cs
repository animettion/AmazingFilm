
using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainModel.Interfaces.Repositories
{
    public interface ICommentRepository : IRepository<Comment,Guid>
    {
        IEnumerable<Comment> SearchByFilm(Guid idFilm);
    }
}
