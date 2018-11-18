using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bookservice.MVC.Models;
using BookServiceLib.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Bookservice.MVC.Controllers
{
    public class BooksController : Controller
    {

        private const string BaseBookUri = "https://localhost:44375/api/books";


        public IActionResult Index()
        {
            var basicBookUri = $"{BaseBookUri}/basic";
            return View(GetApiResult<List<BookBasic>>(basicBookUri));
        }

        public T GetApiResult<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<string> response = httpClient.GetStringAsync(uri);
                return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(response.Result)).Result;
            }
        }

        public IActionResult Detail(int id)
        {
            var geekJokesUri = "https://geek-jokes.sameerkumar.website/api";
            var ipsumUri = "https://baconipsum.com/api/?type=meat-andfiller&paras=2&format=text";
            var bookUri = $"{BaseBookUri}/detail/{id}";

            return View( new BookDetailExtraViewModel
            {
                BookDetail = GetApiResult<BookDetail>(bookUri),
                AuthorJoke = GetApiResult<string>(geekJokesUri),
                BookSummary = new HttpClient().GetStringAsync(ipsumUri).Result
            });
        }
    }
}