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
    public class UsersController : Controller
    {
        private readonly BookStoreDeskContext _context;

        public UsersController(BookStoreDeskContext context)
        {
            ViewBag.Title = "Users";
            _context = context;
        }

        // GET: Users
        [ServiceFilter(typeof(ControllerFilterAdmin))]
        public ActionResult Index()
        {
            var service = new UserService(HttpContext.Session.GetString("Token"));
            var items = service.Get();

            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = new UserService(HttpContext.Session.GetString("Token"));
            var items = service.Get((int)id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: Users/Create
        [ServiceFilter(typeof(ControllerFilterAdmin))]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ServiceFilter(typeof(ControllerFilterAdmin))]
        public async Task<IActionResult> Create([Bind("Id,Name,Password,Username,IsAdmin,Birthday")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var service = new UserService(HttpContext.Session.GetString("Token"));
                var items = service.Create(userViewModel);
                if (items == null)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        // PUT: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = new UserService(HttpContext.Session.GetString("Token"));
            var items = service.Get((int)id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Password,Username,IsAdmin,Birthday")] UserViewModel userViewModel)
        {
            if (id != userViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var service = new UserService(HttpContext.Session.GetString("Token"));
                var item = service.Get((int)id);
                if (item == null) return NotFound();

                var items = service.Edit(userViewModel);
                if (items == null) return BadRequest();

                return RedirectToAction(nameof(Index));
            }
            return View(userViewModel);
        }

        // DELETE: Users/Delete/5
        [ServiceFilter(typeof(ControllerFilterAdmin))]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = new UserService(HttpContext.Session.GetString("Token"));
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
