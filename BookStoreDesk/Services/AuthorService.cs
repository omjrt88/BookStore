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
    public class AuthorService
    {
        private string _token;

        public AuthorService(string token)
        {
            _token = token;
        }
        public List<AuthorViewModel> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                //HTTP GET
                var responseTask = client.GetAsync("authors");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<AuthorViewModel>>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (List<AuthorViewModel>)alldata;
                }
            }

            return null;
        }

        public AuthorViewModel Get(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                //HTTP GET
                var responseTask = client.GetAsync($"authors/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AuthorViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (AuthorViewModel)alldata;
                }
            }

            return null;
        }

        public AuthorViewModel Create(AuthorViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var responseTask = client.PostAsync("authors", stringContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AuthorViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (AuthorViewModel)alldata;
                }
            }
            return null;
        }

        public AuthorViewModel Edit(AuthorViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var responseTask = client.PutAsync("authors", stringContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<AuthorViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (AuthorViewModel)alldata;
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
                var responseTask = client.DeleteAsync($"authors/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                return result.IsSuccessStatusCode;
            }
        }
    }
}
