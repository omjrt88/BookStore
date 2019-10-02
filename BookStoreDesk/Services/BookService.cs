using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesk.Models;
using Newtonsoft.Json;

namespace BookStoreDesk.Services
{
    public class BookService
    {
        private string _token;

        public BookService(string token)
        {
            _token = token;
        }
        public List<BookViewModel> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                //HTTP GET
                var responseTask = client.GetAsync("books");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookViewModel>>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (List<BookViewModel>)alldata;
                }
            }

            return null;
        }

        public BookViewModel Get(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                //HTTP GET
                var responseTask = client.GetAsync($"books/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BookViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (BookViewModel)alldata;
                }
            }

            return null;
        }

        public BookViewModel Create(BookViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var responseTask = client.PostAsync("books", stringContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BookViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (BookViewModel)alldata;
                }
            }
            return null;
        }

        public BookViewModel Edit(BookViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var responseTask = client.PutAsync("books", stringContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<BookViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (BookViewModel)alldata;
                }
            }
            return null;
        }

        public bool Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                var responseTask = client.DeleteAsync($"books/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                return result.IsSuccessStatusCode;
            }
        }

        public List<BookViewModel> TrendingBooks()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                //HTTP GET
                var responseTask = client.GetAsync("books/TrendingBooks");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookViewModel>>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (List<BookViewModel>)alldata;
                }
            }

            return null;
        }

        public List<BookViewModel> NewestBooks()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                //HTTP GET
                var responseTask = client.GetAsync("books/NewestBooks");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<BookViewModel>>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (List<BookViewModel>)alldata;
                }
            }

            return null;
        }
    }
}
