using System.IO;
using System.Threading.Tasks;
using BookService.WebApi.Repositories;
using BookServiceLib.Models;
using Microsoft.AspNetCore.Http;
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

        // GET: api/Books/Detail/6
        [HttpGet]
        [Route("Detail/{id}")]
        public async Task<IActionResult> GetBookDetail(int id)
        {
            return Ok(await Repository.GetDetailById(id));

        }

        // Get: api/Books/Statistics
        [HttpGet]
        [Route("Statistics")]
        public async Task<IActionResult> GetBookStatistics()
        {
            return Ok(await Repository.GetStatistics());
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

        // POST api/books/image
        [HttpPost]
        [Route("Image")]
        public async Task<IActionResult> Image(IFormFile formFile)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", formFile.FileName);

            if (formFile.Length > 0)
            {
                using ( var stream = new FileStream(filePath, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
            }
            return Ok(new {count = 1, formFile.Length});
        }


    }
}