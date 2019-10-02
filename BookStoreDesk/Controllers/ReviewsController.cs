using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreDesk.Models;
using Bookstore.Models;
using BookStoreDesk.ActionFilters;
using BookStoreDesk.Services;
using BookStoreDesk.Utils;
using Microsoft.AspNetCore.Http;

namespace BookStoreDesk.Controllers
{
    [ServiceFilter(typeof(ControllerFilterBookStore))]
    public class ReviewsController : Controller
    {
        private readonly BookStoreDeskContext _context;

        public ReviewsController(BookStoreDeskContext context)
        {
            ViewBag.Title = "Reviews";
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var service = new ReviewService(HttpContext.Session.GetString("Token"));
            var items = service.Get();

            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var service = new ReviewService(HttpContext.Session.GetString("Token"));
            var items = service.Get((int)id);
            if (items == null) return NotFound();

            return View(items);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            var bookService = new BookService(HttpContext.Session.GetString("Token"));
            var userService = new UserService(HttpContext.Session.GetString("Token"));
            ViewData["BookId"] = new SelectList(bookService.Get(), "Id", "Name");
            ViewData["UserId"] = new SelectList(userService.Get(), "Id", "Name");
            ViewData["Qualification"] = new SelectList(Common.Reviews, "Value", "Key");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,BookId,Created,Qualification,Comment")] ReviewViewModel reviewViewModel)
        {
            if (ModelState.IsValid)
            {
                var service = new ReviewService(HttpContext.Session.GetString("Token"));
                var items = service.Create(reviewViewModel);
                if (items == null)
                {
                    return BadRequest();
                }
                return RedirectToAction(nameof(Index));
            }
            var bookService = new BookService(HttpContext.Session.GetString("Token"));
            var userService = new UserService(HttpContext.Session.GetString("Token"));
            ViewData["BookId"] = new SelectList(bookService.Get(), "Id", "Name", reviewViewModel.BookId);
            ViewData["UserId"] = new SelectList(userService.Get(), "Id", "Name", reviewViewModel.UserId);
            ViewData["Qualification"] = new SelectList(Common.Reviews, "Value", "Key", reviewViewModel.Qualification);
            return View(reviewViewModel);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var service = new ReviewService(HttpContext.Session.GetString("Token"));
            var reviewViewModel = service.Get((int)id);

            if (reviewViewModel == null) return NotFound();

            var bookService = new BookService(HttpContext.Session.GetString("Token"));
            var userService = new UserService(HttpContext.Session.GetString("Token"));
            ViewData["BookId"] = new SelectList(bookService.Get(), "Id", "Name", reviewViewModel.BookId);
            ViewData["UserId"] = new SelectList(userService.Get(), "Id", "Name", reviewViewModel.UserId);
            ViewData["Qualification"] = new SelectList(Common.Reviews, "Value", "Key", reviewViewModel.Qualification);

            return View(reviewViewModel);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,BookId,Created,Qualification,Comment")] ReviewViewModel reviewViewModel)
        {
            if (id != reviewViewModel.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var service = new ReviewService(HttpContext.Session.GetString("Token"));
                var item = service.Get((int)id);
                if (item == null) return NotFound();

                var items = service.Edit(reviewViewModel);
                if (items == null) return BadRequest();

                return RedirectToAction(nameof(Index));
            }

            var bookService = new BookService(HttpContext.Session.GetString("Token"));
            var userService = new UserService(HttpContext.Session.GetString("Token"));
            ViewData["BookId"] = new SelectList(bookService.Get(), "Id", "Name", reviewViewModel.BookId);
            ViewData["UserId"] = new SelectList(userService.Get(), "Id", "Name", reviewViewModel.UserId);
            ViewData["Qualification"] = new SelectList(Common.Reviews, "Value", "Key", reviewViewModel.Qualification);
            return View(reviewViewModel);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var service = new ReviewService(HttpContext.Session.GetString("Token"));
            var item = service.Get((int)id);
            if (item == null) return NotFound();

            var items = service.Delete((int)id);
            if (!items) return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
