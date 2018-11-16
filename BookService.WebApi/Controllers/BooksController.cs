using System.IO;
using System.Threading.Tasks;
using BookService.WebApi.DTO;
using BookService.WebApi.Repositories;
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
        public async Task<IActionResult> GetBooks()
        {
            return Ok( await _repository.GetAllInclusive());
        }

        // Get: api/Book/Basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetBookBasic()
        {
            return Ok(await _repository.ListbBasic());
        }

        // Get: api/books/6
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            return Ok( await _repository.GetById(id));
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
        public async Task<IActionResult> ImageById(int id)
        {
            var book = await _repository.GetById(id);
            return ImageByName(book.FileName);

        }


    }
}