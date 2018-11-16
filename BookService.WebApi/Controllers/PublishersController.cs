using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherRepository _repository;

        public PublishersController(PublisherRepository repository)
        {
            _repository = repository;
        }


        // api/publishers
        public IActionResult GetPublishers()
        {
            return Ok(_repository.List());
        }

        // api/publishers/2
        [Route("{id}")]
        public IActionResult GetPublisher(int id)
        {
            return Ok(_repository.GetById(id));
        }
    }
}