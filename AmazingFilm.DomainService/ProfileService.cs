using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AmazingFilm.DomainService
{
    public class ProfileService
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

        public IEnumerable<Profile> SearchByName(string name)
        {
            return _ProfileRepository.ReadAll()
                .Where(c => c.Name.ToLower()
                .Contains(name.ToLower()));
        }
    }
}
