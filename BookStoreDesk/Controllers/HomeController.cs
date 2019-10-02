using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BookStoreDesk.ActionFilters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStoreDesk.Models;
using BookStoreDesk.Services;
using Newtonsoft.Json;

namespace BookStoreDesk.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            //IsUserLogged();
        }
        public IActionResult Index()
        {
            IsUserLogged();
            if (!ViewBag.isLogged)
            {
                return RedirectToAction(nameof(Login));
            }
            else
            {
                return RedirectToAction(nameof(Trending));
            }
        }

        public IActionResult Privacy()
        {
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Login()
        {
            ModelState.Clear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Username,Name,Password")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var service = new UserService("");
                var token = service.Login(userViewModel);
                if (token == null)
                {
                    ModelState.AddModelError("ModelError", "Invalid Username/Password");
                }
                else
                {
                    HttpContext.Session.SetString("Token", token);
                    service = new UserService(token);
                    UserViewModel user = service.Get(userViewModel.Username);
                    HttpContext.Session.SetString("UserData", JsonConvert.SerializeObject(user));
                    return RedirectToAction(nameof(Trending));
                }
            }
            return View(userViewModel);
        }

        [ServiceFilter(typeof(ControllerFilterBookStore))]
        public IActionResult Trending()
        {
            var service = new BookService(HttpContext.Session.GetString("Token"));
            var trending = service.TrendingBooks();

            service = new BookService(HttpContext.Session.GetString("Token"));
            var newest = service.NewestBooks();

            var trendingModel = new TrendingViewModel{NewestBooks = newest, TrendingBooks = trending};

            return View(trendingModel);
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("Token");
            HttpContext.Session.Remove("UserData");
            return RedirectToAction(nameof(Index));
        }

        private void IsUserLogged()
        {
            if (HttpContext.Session.Keys.Contains("Token"))
            {
                string token = HttpContext.Session.GetString("Token");
                ViewBag.isLogged = !string.IsNullOrEmpty(token);
            }
            else
            {
                ViewBag.isLogged = false;
            }
        }
    }
}
