using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingFilm.DomainModel.Entities
{
    public class Comment : EntityBase<Guid>
    {

        public Guid ProfileId { get; set; }

        public Guid FilmId { get; set; }
        public string Text { get; set; }
        public DateTime PublishDateTime { get; set; }

        public Film film { get; set; }

        
        public virtual Profile profile { get; set; }
        public Comment()
        {
            PublishDateTime = DateTime.Now;
        }
    }
}
