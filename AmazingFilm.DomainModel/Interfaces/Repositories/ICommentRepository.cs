
using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingComment.DomainModel.Interfaces.Repositories
{
    public interface ICommentRepository : IRepository<Comment,Guid>
    {
        IEnumerable<Comment> FindByName(string name);
    }
}
