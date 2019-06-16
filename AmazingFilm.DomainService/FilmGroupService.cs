
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using AmazingFilm.DomainModel.Entities;

namespace AmazingFilmGroup.DomainService
{
    public class FilmGroupService
    {
        private IFilmGroupRepository _FilmGroupRepository;

        public FilmGroupService(IFilmGroupRepository FilmGroupRepository)
        {
            _FilmGroupRepository = FilmGroupRepository;
        }

        public void AddFilmGroup(FilmGroup FilmGroup)
        {
            _FilmGroupRepository.Create(FilmGroup);
        }

        public IEnumerable<FilmGroup> GetAllFilmGroups()
        {
            return _FilmGroupRepository.ReadAll();
        }

        public FilmGroup GetFilmGroupById(Guid id)
        {
            return _FilmGroupRepository.Read(id);
        }

        public IEnumerable<FilmGroup> SearchByName(string name)
        {
            return _FilmGroupRepository.ReadAll()
                .Where(c => c.Name.ToLower()
                .Contains(name.ToLower()));
        }
    }
}
