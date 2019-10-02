using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class BooksController : Controller
    {
        private readonly BookStoreDeskContext _context;

        public BooksController(BookStoreDeskContext context)
        {
            ViewBag.Title = "Books";
            _context = context;
        }

        // GET: Books
        public ActionResult Index()
        {
            var service = new BookService(HttpContext.Session.GetString("Token"));
            var items = service.Get();

            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = new BookService(HttpContext.Session.GetString("Token"));
            var items = service.Get((int)id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            var authorService = new AuthorService(HttpContext.Session.GetString("Token"));
            var categoryService = new CategoryService(HttpContext.Session.GetString("Token"));
            ViewData["AuthorId"] = new SelectList(authorService.Get(), "Id", "Name");
            ViewData["CategoryId"] = new SelectList(categoryService.Get(), "Id", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Published,CategoryId,AuthorId")] BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                var service = new BookService(HttpContext.Session.GetString("Token"));
                var items = service.Create(bookViewModel);
                if (items == null)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            var authorService = new AuthorService(HttpContext.Session.GetString("Token"));
            var categoryService = new CategoryService(HttpContext.Session.GetString("Token"));
            ViewData["AuthorId"] = new SelectList(authorService.Get(), "Id", "Name", bookViewModel.AuthorId);
            ViewData["CategoryId"] = new SelectList(categoryService.Get(), "Id", "Name", bookViewModel.CategoryId);
            return View(bookViewModel);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var service = new BookService(HttpContext.Session.GetString("Token"));
            var bookViewModel = service.Get((int)id);

            if (bookViewModel == null) return NotFound();

            var authorService = new AuthorService(HttpContext.Session.GetString("Token"));
            var categoryService = new CategoryService(HttpContext.Session.GetString("Token"));
            ViewData["AuthorId"] = new SelectList(authorService.Get(), "Id", "Name", bookViewModel.AuthorId);
            ViewData["CategoryId"] = new SelectList(categoryService.Get(), "Id", "Name", bookViewModel.CategoryId);
            return View(bookViewModel);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Published,CategoryId,AuthorId")] BookViewModel bookViewModel)
        {
            if (id != bookViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var service = new BookService(HttpContext.Session.GetString("Token"));
                var item = service.Get((int)id);
                if (item == null) return NotFound();

                var items = service.Edit(bookViewModel);
                if (items == null) return BadRequest();

                return RedirectToAction(nameof(Index));
            }
            var authorService = new AuthorService(HttpContext.Session.GetString("Token"));
            var categoryService = new CategoryService(HttpContext.Session.GetString("Token"));
            ViewData["AuthorId"] = new SelectList(authorService.Get(), "Id", "Name", bookViewModel.AuthorId);
            ViewData["CategoryId"] = new SelectList(categoryService.Get(), "Id", "Name", bookViewModel.CategoryId);
            return View(bookViewModel);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var service = new BookService(HttpContext.Session.GetString("Token"));
            var item = service.Get((int)id);
            if (item == null) return NotFound();

            var items = service.Delete((int)id);
            if (!items) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
