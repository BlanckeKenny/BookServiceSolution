using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BookServiceLib.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bookservice.MVC.Controllers
{
    public class BooksController : Controller
    {

        private const string BaseUri = "https://localhost:44375/api/books";


        public IActionResult Index()
        {
            string BookUri = $"{BaseUri}/basic";
            return View(GetApiResult<List<BookBasic>>(BookUri));
        }



        public T GetApiResult<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(uri);
                return Task.Factory.StartNew(
                    () => JsonConvert.DeserializeObject<T>(response.Result)
                ).Result;
            }
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}