using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AmazingFilm.DomainService
{
    public class FilmService
    {
        private IFilmRepository _FilmRepository;

        public FilmService(IFilmRepository FilmRepository)
        {
            _FilmRepository = FilmRepository;
        }

        public void AddFilm(Film Film)
        {
            _FilmRepository.Create(Film);
        }

        public IEnumerable<Film> GetAllFilms()
        {
            return _FilmRepository.ReadAll();
        }

        public Film GetFilmById(Guid id)
        {
            return _FilmRepository.Read(id);
        }

        public IEnumerable<Film> SearchByName(string name)
        {
            return _FilmRepository.ReadAll()
                .Where(c => c.Name.ToLower()
                .Contains(name.ToLower()));
        }
    }
}
