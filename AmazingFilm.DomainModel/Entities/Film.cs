using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainModel.Entities
{
    public class Film : EntityBase<Guid>
    {
        public Film()
        {
            Comments = new List<Comment>();
        }

        public string Name { get; set; }
        //public virtual FilmGroup Group { get; set; }
        public Guid IdGroup { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
