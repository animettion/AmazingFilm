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

namespace AmazingFilm.WebApp.Controllers
{
    public class FilmGroupsController : Controller
    {
        private readonly AmazingFilmContext _context;

        public FilmGroupsController()
        {
            AmazingFilmContext context = new AmazingFilmContext();
            _context = context;
        }

        // GET: FilmGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.FilmGroups.ToListAsync());
        }

        // GET: FilmGroups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filmGroup = await _context.FilmGroups
                .FirstOrDefaultAsync(m => m.Id == id);
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
                _context.Add(filmGroup);
                await _context.SaveChangesAsync();
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

            var filmGroup = await _context.FilmGroups.FindAsync(id);
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
                    _context.Update(filmGroup);
                    await _context.SaveChangesAsync();
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

            var filmGroup = await _context.FilmGroups
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var filmGroup = await _context.FilmGroups.FindAsync(id);
            _context.FilmGroups.Remove(filmGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmGroupExists(Guid id)
        {
            return _context.FilmGroups.Any(e => e.Id == id);
        }
    }
}
