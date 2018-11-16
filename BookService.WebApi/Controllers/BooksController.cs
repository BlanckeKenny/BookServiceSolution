using System.IO;
using System.Threading.Tasks;
using BookService.WebApi.DTO;
using BookService.WebApi.Models;
using BookService.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerCrudBase<Book, BookRepository>
    {

        public BooksController(BookRepository repository)  :base (repository)
        {
        }

        // Get: api/Book
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok( await Repository.GetAllInclusive());
        }

        // Get: api/Book/Basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetBookBasic()
        {
            return Ok(await Repository.ListbBasic());
        }

        // Get: api/books/imagebyname/book2.jpg
        [HttpGet]
        [Route("imagebyname/{filename}")]
        public IActionResult ImageByName(string filename)
        {
            var image = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "images", filename);
            return PhysicalFile(image, "image/jpeg");
        }

        // get: api/Books/imagebyId/2
        [HttpGet]
        [Route("imagebyid/{id}")]
        public async Task<IActionResult> ImageById(int id)
        {
            var book = await Repository.GetById(id);
            return ImageByName(book.FileName);

        }


    }
}