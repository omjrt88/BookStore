using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using BookStoreDesk.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreDesk.Models;
using BookStoreDesk.Services;
using Microsoft.AspNetCore.Http;

namespace BookStoreDesk.Controllers
{
    [ServiceFilter(typeof(ControllerFilterBookStore))]
    public class AuthorsController : Controller
    {
        private readonly BookStoreDeskContext _context;

        public AuthorsController(BookStoreDeskContext context)
        {
            ViewBag.Title = "Author";
            _context = context;
        }

        // GET: Author
        public ActionResult Index()
        {
            var service = new AuthorService(HttpContext.Session.GetString("Token"));
            var items = service.Get();

            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: Author/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = new AuthorService(HttpContext.Session.GetString("Token"));
            var items = service.Get((int)id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: Author/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Birthday")] AuthorViewModel authorViewModel)
        {
            if (ModelState.IsValid)
            {
                var service = new AuthorService(HttpContext.Session.GetString("Token"));
                var items = service.Create(authorViewModel);
                if (items == null)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(authorViewModel);
        }

        // PUT: Author/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = new AuthorService(HttpContext.Session.GetString("Token"));
            var items = service.Get((int)id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // POST: Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Birthday")] AuthorViewModel authorViewModel)
        {
            if (id != authorViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var service = new AuthorService(HttpContext.Session.GetString("Token"));
                var item = service.Get((int)id);
                if (item == null) return NotFound();

                var items = service.Edit(authorViewModel);
                if (items == null) return BadRequest();

                return RedirectToAction(nameof(Index));
            }
            return View(authorViewModel);
        }

        // DELETE: Author/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = new AuthorService(HttpContext.Session.GetString("Token"));
            var item = service.Get((int)id);
            if (item == null) return NotFound();

            var items = service.Delete((int)id);
            if (!items)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
