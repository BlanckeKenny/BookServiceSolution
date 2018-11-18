using System.Collections.Generic;
using BookService.Lib.Helpers;
using BookServiceLib.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Bookservice.MVC.Controllers
{
    public class AuthorsController : Controller
    {

        const string baseUri = "https://localhost:44375/api/Authors";

        public IActionResult Index()
        {
            string uri = $"{baseUri}/basic";
            return View(WebApiHelper.GetApiResult<List<AuthorBasic>>(uri));
        }
    }
}