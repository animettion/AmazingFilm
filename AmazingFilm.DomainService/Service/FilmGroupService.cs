
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainService.Interfaces;

namespace AmazingFilm.DomainService
{
    public class FilmGroupService : IFilmGroupService
    {
        private readonly IFilmGroupRepository _FilmGroupRepository;

        public FilmGroupService(IFilmGroupRepository FilmGroupRepository)
        {
            _FilmGroupRepository = FilmGroupRepository;
        }

        public void AddFilmGroup(FilmGroup FilmGroup)
        {
            _FilmGroupRepository.Create(FilmGroup);
        }

        public void UpdateFilmGroup(FilmGroup FilmGroup)
        {
            _FilmGroupRepository.Update(FilmGroup);
        }

        public void DeleteFilmGroup(Guid id)
        {
            _FilmGroupRepository.Delete(id);
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
