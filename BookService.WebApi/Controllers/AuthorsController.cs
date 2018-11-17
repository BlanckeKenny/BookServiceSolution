using System.Threading.Tasks;
using BookService.WebApi.Repositories;
using BookServiceLib.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookService.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerCrudBase<Author, AuthorRepository>
    {
        public AuthorsController(AuthorRepository authorsRepository) : base (authorsRepository)
        {

        }

        // api/authors/basic
        [Route("Basic")]
        public async Task<IActionResult> GetAuthorBasic()
        {
            return Ok( await Repository.ListBasic());
        }

    }
}