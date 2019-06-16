using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingFilm.DomainModel.Entities
{
    public class Comment : EntityBase<Guid>
    {
        public Film Film { get; set; }
        public Profile Sender { get; set; }
        public string Content { get; set; }
        public DateTime PublishDateTime { get; set; }

        public Comment()
        {
            PublishDateTime = DateTime.Now;
        }
    }
}
