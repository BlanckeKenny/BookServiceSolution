using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebApi.DTO;
using BookService.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _repository;

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

        // Get: api/books/6
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBook(int id)
        {
            return Ok(_repository.GetById(id));
        }

        // Get: api/imagebyname/book2.jpg
        [HttpGet]
        [Route("imagebyname/{filename}")]
        public IActionResult ImageByName(string filename)
        {
            var image = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "images", filename);
            return PhysicalFile(image, "image/jpeg");
        }

        // get: api/imagebyId/2
        [HttpGet]
        [Route("imagebyid/{id}")]
        public IActionResult ImageById(int id)
        {
            BookDetail book = _repository.GetById(id);
            return ImageByName(book.FileName);

        }


    }
}