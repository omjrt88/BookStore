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
    public class UserService
    {
        private string _token;

        public UserService(string token)
        {
            _token = token;
        }
        public List<UserViewModel> Get()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                //HTTP GET
                var responseTask = client.GetAsync("users");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<UserViewModel>>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (List<UserViewModel>)alldata;
                }
            }

            return null;
        }

        public UserViewModel Get(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                //HTTP GET
                var responseTask = client.GetAsync($"users/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (UserViewModel)alldata;
                }
            }

            return null;
        }

        public UserViewModel Get(string username)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
                //HTTP GET
                var responseTask = client.GetAsync($"users/GetbyUser/{username}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (UserViewModel)alldata;
                }
            }

            return null;
        }


        public UserViewModel Create(UserViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var responseTask = client.PostAsync("users", stringContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (UserViewModel)alldata;
                }
            }
            return null;
        }

        public UserViewModel Edit(UserViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var responseTask = client.PutAsync("users", stringContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<UserViewModel>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (UserViewModel)alldata;
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
                var responseTask = client.DeleteAsync($"users/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                return result.IsSuccessStatusCode;
            }
        }

        public string Login(UserViewModel model)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:5001/api/");

                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                var responseTask = client.PostAsync("auth", stringContent);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<dynamic>();
                    readTask.Wait();

                    var alldata = readTask.Result;

                    return (string)alldata.token;
                }
            }
            return null;
        }
    }
}
