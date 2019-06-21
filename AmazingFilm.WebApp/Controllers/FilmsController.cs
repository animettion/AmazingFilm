using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmazingFilm.DomainModel.Entities;
using AmazingFilm.Infrastructure.DataAccess.Contexts;
using AmazingFilm.Infrastructure.AzureStorage;
using AmazingFilm.DomainService.Interfaces;
using System.Dynamic;

namespace AmazingFilm.WebApp.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IFilmService _service;
        private readonly IFilmGroupService _servicegroup;
        private readonly ICommentService _servicecomment;
        private readonly IProfileService _serviceprofile;

        public FilmsController(IFilmService serv, IFilmGroupService servgroup, ICommentService servcomment, IProfileService servprofile)
        {
            _service = serv;
            _servicegroup = servgroup;
            _servicecomment = servcomment;
            _serviceprofile = servprofile;
        }

        // GET: Films
        public async Task<IActionResult> Index()
        {
            return View(_service.GetAllFilms().OrderBy(p => p.Name).ToList());
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            var film = _service.GetFilmById(id.Value);
            if (film == null)
            {
                return NotFound();
            }
            //dynamic mymodel = new ExpandoObject();
            //ViewBag.Film = film;
            //ViewBag.Comment = _servicecomment.GetByFilm(film.Id);
           
            return View(film);
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            ViewBag.Groups = _servicegroup.GetAllFilmGroups().Select(c => new SelectListItem()
            { Text = c.Name, Value = c.Id.ToString() }).ToList();

            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,PhotoUrl,Id,IdGroup")] Film film)
        {
            if (ModelState.IsValid)
            {
                film.Id = Guid.NewGuid();

                //==== Upload da foto do Cliente ====
                for (int i = 0; i < Request.Form.Files.Count; i++)
                {
                    var file = Request.Form.Files[i];
                    var blobService = new AzureBlobService();
                    film.PhotoUrl = blobService.UploadFile(file.FileName, file.OpenReadStream(), "photofilm", file.ContentType);
                }
                //===================================

                _service.AddFilm(film);
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = _service.GetFilmById(id.Value);
            if (film == null)
            {
                return NotFound();
            }

            ViewBag.Groups = _servicegroup.GetAllFilmGroups().Select(c => new SelectListItem()
            { Text = c.Name, Value = c.Id.ToString() }).ToList();

            return View(film);
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description,PhotoUrl,Id,IdGroup")] Film film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //==== Upload da foto do Cliente ====
                    for (int i = 0; i < Request.Form.Files.Count; i++)
                    {
                        var file = Request.Form.Files[i];
                        var blobService = new AzureBlobService();
                        film.PhotoUrl = blobService.UploadFile(file.FileName, file.OpenReadStream(), "photofilm", file.ContentType);
                    }
                    //===================================

                    _service.UpdateFilm(film);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.Id))
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
            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = _service.GetFilmById(id.Value);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var film = _service.GetFilmById(id);
            _service.DeleteFilm(id);
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(Guid id)
        {
            return _service.GetFilmById(id) != null;
        }
    }
}
