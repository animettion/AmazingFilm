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
            FilmRatings = new List<FilmRating>();
        }

        public string Name { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<FilmRating> FilmRatings { get; set; }

    }
}
