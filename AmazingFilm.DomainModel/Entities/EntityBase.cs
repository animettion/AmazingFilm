using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainModel.Entities
{
    public abstract class EntityBase<EntityId>
    {

        public Guid Id { get; set; }

        public virtual bool IsValid()
        {
            return true;
        }
    }
}
