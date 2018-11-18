using System.Collections.Generic;
using BookService.Lib.Helpers;
using BookServiceLib.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookservice.MVC.Controllers
{
    public class PublishersController : Controller
    {
        private const string BasicPublishersUri = "https://localhost:44375/api/publishers";

        public IActionResult Index()
        {
            string allPublishersUri = $"{BasicPublishersUri}";
            return View(GetApiResultHelper.GetApiResult<List<Publisher>>(allPublishersUri));
        }

        public IActionResult Detail(int id)
        {
            string publisherDetailUri = $"{BasicPublishersUri}/{id}";
            return View(GetApiResultHelper.GetApiResult<Publisher>(publisherDetailUri));
        }


    }
}