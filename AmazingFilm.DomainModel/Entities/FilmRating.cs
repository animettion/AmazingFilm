using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainModel.Entities
{
    public class FilmRating : EntityBase<Guid>
    {

        public Guid ProfileId { get; set; }
        public Guid FilmId { get; set; }
        
        public bool liked { get; set; }
        public DateTime PublishDateTime { get; set; }
        public Film film { get; set; }
        public virtual Profile profile { get; set; }

        public FilmRating()
        {
            PublishDateTime = DateTime.Now;
        }

    }
}
