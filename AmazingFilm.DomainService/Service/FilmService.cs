using AmazingFilm.DomainModel.Entities;
using AmazingFilm.DomainModel.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AmazingFilm.DomainService.Interfaces;

namespace AmazingFilm.DomainService
{
    public class FilmService: IFilmService
    {
        private readonly IFilmRepository _FilmRepository;

        public FilmService(IFilmRepository FilmRepository)
        {
            _FilmRepository = FilmRepository;
        }   

        public void AddFilm(Film Film)
        {
            _FilmRepository.Create(Film);
        }

        public void UpdateFilm(Film Film)
        {
            _FilmRepository.Update(Film);
        }

        public void DeleteFilm(Guid id)
        {
            _FilmRepository.Delete(id);
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
