using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazingFilm.DomainModel.Entities
{
    public class Profile : EntityBase<Guid>
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }        
        public string PhotoUrl { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        

        public Profile()
        {
        
        }
        
    }
}
