using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmazingFilm.DomainModel.Entities;
using AmazingFilm.WebApp.Data;
using AmazingFilm.Infrastructure.DataAccess.Contexts;
using AmazingFilm.DomainService;
using AmazingFilm.DomainService.Interfaces;

namespace AmazingFilm.WebApp.Controllers
{
    public class FilmGroupsController : Controller
    {
        private readonly IFilmGroupService _service;

        public FilmGroupsController(IFilmGroupService serv)
        {   
            _service = serv;
        }

        // GET: FilmGroups
        public async Task<IActionResult> Index()
        {
            return View(_service.GetAllFilmGroups());
        }

        // GET: FilmGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmGroup = _service.GetFilmGroupById(id.Value);
            if (filmGroup == null)
            {
                return NotFound();
            }

            return View(filmGroup);
        }

        // GET: FilmGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FilmGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] FilmGroup filmGroup)
        {
            if (ModelState.IsValid)
            {
                filmGroup.Id = Guid.NewGuid();
                
                _service.AddFilmGroup(filmGroup);
                return RedirectToAction(nameof(Index));
            }
            return View(filmGroup);
        }

        // GET: FilmGroups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmGroup = _service.GetFilmGroupById(id.Value);
            if (filmGroup == null)
            {
                return NotFound();
            }
            return View(filmGroup);
        }

        // POST: FilmGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id")] FilmGroup filmGroup)
        {
            if (id != filmGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.UpdateFilmGroup(filmGroup);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmGroupExists(filmGroup.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(filmGroup);
        }

        // GET: FilmGroups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmGroup = _service.GetFilmGroupById(id.Value);
            if (filmGroup == null)
            {
                return NotFound();
            }

            return View(filmGroup);
        }

        // POST: FilmGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            
            _service.DeleteFilmGroup(id);
            return RedirectToAction(nameof(Index));
        }

        private bool FilmGroupExists(Guid id)
        {
            return _service.GetFilmGroupById(id) != null;
        }
    }
}
