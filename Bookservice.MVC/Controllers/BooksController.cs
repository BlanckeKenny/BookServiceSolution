using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Bookservice.MVC.Models;
using BookService.Lib.Helpers;
using BookServiceLib.DTO;
using Microsoft.AspNetCore.Mvc;
namespace Bookservice.MVC.Controllers
{
    public class BooksController : Controller
    {

        private const string BaseBookUri = "https://localhost:44375/api/books";


        public IActionResult Index()
        {
            var basicBookUri = $"{BaseBookUri}/basic";
            return View(WebApiHelper.GetApiResult<List<BookBasic>>(basicBookUri));
        }

        public IActionResult IndexVue()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var geekJokesUri = "https://geek-jokes.sameerkumar.website/api";
            var ipsumUri = "https://baconipsum.com/api/?type=meat-andfiller&paras=2&format=text";
            var bookUri = $"{BaseBookUri}/detail/{id}";

            return View( new BookDetailExtraViewModel
            {
                BookDetail = WebApiHelper.GetApiResult<BookDetail>(bookUri),
                AuthorJoke = WebApiHelper.GetApiResult<string>(geekJokesUri),
                BookSummary = new HttpClient().GetStringAsync(ipsumUri).Result
            });
        }
    }
}