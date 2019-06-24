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

namespace AmazingFilm.WebApp.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService _service;

        public CommentsController(ICommentService serv)
        {
            _service = serv;
        }

        // GET: Comments
        public async Task<IActionResult> Index(Guid Id)
        {
            return View(_service.GetByFilm(Id).OrderByDescending(p => p.Id).ToList());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Comments = _service.GetCommentById(id.Value);
            if (Comments == null)
            {
                return NotFound();
            }


            return View(Comments);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,PhotoUrl,Id,GroupName")] Comment _Comment)
        {
            if (ModelState.IsValid)
            {
                _Comment.Id = Guid.NewGuid();

                _service.AddComment(_Comment);
                return RedirectToAction(nameof(Index));
            }
            return View(_Comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Comment = _service.GetCommentById(id.Value);
            if (Comment == null)
            {
                return NotFound();
            }
            return View(Comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Content,PublishDateTime,Id")] Comment comment)
        {

            return View();
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {

            return View();
        }


    }
}
