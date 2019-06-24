using AmazingFilm.DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AmazingFilm.DomainModel.ValueObjects
{
    public class FilmGroup //: EntityBase<Guid>
    {
        [Key]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        public FilmGroup(string name)
        {
            Name = name;
        }

        public FilmGroup()
        {
        }

        public static FilmGroup Parse(string name)
        {
            return new FilmGroup(name);
        }

        

    }
}
