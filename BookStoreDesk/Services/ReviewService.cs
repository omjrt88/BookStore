using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Bookstore.Models;
using BookStoreDesk.Models;
using Newtonsoft.Json;

namespace BookStoreDesk.Services
{
    public class ReviewService
    {
        private string _token;

        public ReviewService(string token)
        {
            _token = token;
        }
        public List<ReviewViewModel> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                //HTTP GET
                var responseTask = client.GetAsync("reviews");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ReviewViewModel>>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (List<ReviewViewModel>)alldata;
                }
            }

            return null;
        }

        public ReviewViewModel Get(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                //HTTP GET
                var responseTask = client.GetAsync($"reviews/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ReviewViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (ReviewViewModel)alldata;
                }
            }

            return null;
        }

        public ReviewViewModel Create(ReviewViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var responseTask = client.PostAsync("reviews", stringContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ReviewViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (ReviewViewModel)alldata;
                }
            }
            return null;
        }

        public ReviewViewModel Edit(ReviewViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var responseTask = client.PutAsync("reviews", stringContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ReviewViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (ReviewViewModel)alldata;
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
                var responseTask = client.DeleteAsync($"reviews/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                return result.IsSuccessStatusCode;
            }
        }
    }
}
