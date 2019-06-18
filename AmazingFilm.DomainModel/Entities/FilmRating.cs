using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainModel.Entities
{
    public class FilmRating : EntityBase<Guid>
    {
        public Profile profile { get; set; }
        public Film film { get; set; }
        public bool watched { get; set; }
        public bool liked { get; set; }
    }
}
