using System.Threading.Tasks;
using BookService.WebApi.Models;
using BookService.WebApi.Repositories;
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
    }
}