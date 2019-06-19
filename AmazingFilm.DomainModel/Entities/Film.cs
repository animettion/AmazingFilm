using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainModel.Entities
{
    public class Film : EntityBase<Guid>
    {

        public string Name { get; set; }
        public virtual FilmGroupFilm Group { get; set; }
        public Guid IdGroup { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }

    }
}
