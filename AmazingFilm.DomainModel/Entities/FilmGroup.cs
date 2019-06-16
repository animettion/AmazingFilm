using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainModel.Entities
{
    public class FilmGroup : EntityBase<Guid>
    {
        public string Name { get; set; }
    }
}
