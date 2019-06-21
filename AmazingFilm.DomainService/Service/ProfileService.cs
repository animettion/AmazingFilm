using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AmazingFilm.DomainService.Interfaces;

namespace AmazingFilm.DomainService
{
    public class ProfileService : IProfileService
    {
        private IProfileRepository _ProfileRepository;

        public ProfileService(IProfileRepository ProfileRepository)
        {
            _ProfileRepository = ProfileRepository;
        }

        public void AddProfile(Profile Profile)
        {
            _ProfileRepository.Create(Profile);
        }

        public IEnumerable<Profile> GetAllProfiles()
        {
            return _ProfileRepository.ReadAll();
        }

        public Profile GetProfileById(Guid id)
        {
            return _ProfileRepository.Read(id);
        }


    }
}
