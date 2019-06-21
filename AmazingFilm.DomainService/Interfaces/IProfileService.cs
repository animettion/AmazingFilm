using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingFilm.DomainService.Interfaces
{
    public interface IProfileService
    {
        void AddProfile(Profile Profile);

        IEnumerable<Profile> GetAllProfiles();

        Profile GetProfileById(Guid id);
        

    }
}
