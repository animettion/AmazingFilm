using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainModel.Entities
{
    public class Film : EntityBase<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<FilmGroup> groups { get; set; }
        public string description { get; set; }
        public string PhotoUrl { get; set; }

    }
}
