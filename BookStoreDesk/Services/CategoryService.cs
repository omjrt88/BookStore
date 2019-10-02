using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesk.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BookStoreDesk.Services
{
    public class CategoryService
    {
        private string _token;

        public CategoryService(string token)
        {
            _token = token;
        }
        public List<CategoryViewModel> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                //HTTP GET
                var responseTask = client.GetAsync("categories");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<CategoryViewModel>>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (List<CategoryViewModel>)alldata;
                }
            }

            return null;
        }

        public CategoryViewModel Get(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                //HTTP GET
                var responseTask = client.GetAsync($"categories/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CategoryViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (CategoryViewModel) alldata;
                }
            }

            return null;
        }

        public CategoryViewModel Create(CategoryViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var responseTask = client.PostAsync("categories", stringContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CategoryViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (CategoryViewModel) alldata;
                }
            }
            return null;
        }

        public CategoryViewModel Edit(CategoryViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var responseTask = client.PutAsync("categories", stringContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CategoryViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (CategoryViewModel)alldata;
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
                var responseTask = client.DeleteAsync($"categories/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                return result.IsSuccessStatusCode;
            }
        }
    }
}
