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
    public class BooksController : ControllerBase
    {
        private BookRepository _repository;

        public BooksController(BookRepository repository)
        {
            _repository = repository;
        }

        // Get: api/Book
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_repository.List());
        }

        // Get: api/Book/Basic
        [HttpGet]
        [Route("Basic")]
        public IActionResult GetBookBasic()
        {
            return Ok(_repository.ListbBasic());
        }

    }
}