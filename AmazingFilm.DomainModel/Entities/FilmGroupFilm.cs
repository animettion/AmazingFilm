using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainModel.Entities
{
    public class FilmGroupFilm : EntityBase<Guid>
    {
        public Guid FilmId { get; set; }
        public Film Film { get; set; }

        public Guid FilmGroupId { get; set; }
        public FilmGroup FilmGroup { get; set; }
    }
}
