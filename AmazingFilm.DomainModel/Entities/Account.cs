using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainModel.Entities
{
    public class Account : EntityBase<Guid>
    {
        public Profile Profile { get; set; }

    }
}
