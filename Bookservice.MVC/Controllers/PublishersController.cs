using System.Collections.Generic;
using System.Threading.Tasks;
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
            return View(WebApiHelper.GetApiResult<List<Publisher>>(allPublishersUri));
        }

        public IActionResult Detail(int id)
        {
            string publisherDetailUri = $"{BasicPublishersUri}/{id}";
            ViewBag.Mode = "Detail";
            return View(WebApiHelper.GetApiResult<Publisher>(publisherDetailUri));
        }

        public IActionResult Edit(int id)
        {
            string uri = $"{BasicPublishersUri}/{id}";
            ViewBag.Mode = "Edit";
            return View("Detail", WebApiHelper.GetApiResult<Publisher>(uri));
        }

        public IActionResult Insert()
        {
            ViewBag.Mode = "Edit";
            return View("Detail", new Publisher());
        }

        [HttpPost]
        public async Task<IActionResult> Save(Publisher publisher)
        {
            if (publisher.Id != 0)
            {
                // update
                string uri = $"{BasicPublishersUri}/{publisher.Id}";
                publisher = await WebApiHelper.PutCallApi<Publisher, Publisher>(uri, publisher);
            }
            else
            {
                // insert
                string uri = $"{BasicPublishersUri}";
                publisher = await WebApiHelper.PostCallApi<Publisher, Publisher>(uri, publisher);
            }

            ViewBag.Mode = "Detail";
            return View("Detail", publisher);
        }

        public async Task<IActionResult> Delete(int id)
        {
            string uri = $"{BasicPublishersUri}/{id}";
            Publisher publisher = await WebApiHelper.DelCallApi<Publisher>(uri);
            return RedirectToAction("Index");
        }
    }
}