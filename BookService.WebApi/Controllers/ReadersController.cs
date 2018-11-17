using BookService.WebApi.Repositories;
using BookServiceLib.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadersController : ControllerCrudBase<Reader, ReaderRepository>
    {
        public ReadersController(ReaderRepository readerRepository) : base (readerRepository)
        {
            
        }
    }
}