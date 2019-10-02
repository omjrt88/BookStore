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
    public class CategoriesController : Controller
    {
        private readonly BookStoreDeskContext _context;

        public CategoriesController(BookStoreDeskContext context)
        {
            ViewBag.Title = "Categories";
            _context = context;
        }

        // GET: Categories
        public ActionResult Index()
        {
            var service = new CategoryService(HttpContext.Session.GetString("Token"));
            var items = service.Get();

            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = new CategoryService(HttpContext.Session.GetString("Token"));
            var items = service.Get((int)id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var service = new CategoryService(HttpContext.Session.GetString("Token"));
                var items = service.Create(categoryViewModel);
                if (items == null)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoryViewModel);
        }

        // PUT: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = new CategoryService(HttpContext.Session.GetString("Token"));
            var items = service.Get((int)id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CategoryViewModel categoryViewModel)
        {
            if (id != categoryViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var service = new CategoryService(HttpContext.Session.GetString("Token"));
                var item = service.Get((int)id);
                if (item == null) return NotFound();

                var items = service.Edit(categoryViewModel);
                if (items == null) return BadRequest();

                return RedirectToAction(nameof(Index));
            }
            return View(categoryViewModel);
        }

        // DELETE: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = new CategoryService(HttpContext.Session.GetString("Token"));
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
