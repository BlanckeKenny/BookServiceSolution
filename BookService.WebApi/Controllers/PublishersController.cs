using System.Threading.Tasks;
using BookService.WebApi.Models;
using BookService.WebApi.Repositories;
using BookServiceLib.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerCrudBase<Publisher, PublisherRepository>
    {

        public PublishersController(PublisherRepository publisherRepository) : base(publisherRepository)
        {
        }


        // GET: api/publishers/Basic
        [HttpGet]
        [Route("basic")]
        public async Task<IActionResult> GetBasic()
        {
            return Ok(await Repository.ListBasic());
        }
    }
}