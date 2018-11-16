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
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorRepository _repositories;

        public AuthorsController(AuthorRepository repositories)
        {
            _repositories = repositories;
        }

        // api/authors
        public async Task<IActionResult> GetAuthors()
        {
            return Ok(await _repositories.ListAll());
        }

        // api/authors/basic
        [Route("Basic")]
        public async Task<IActionResult> GetAuthorBasic()
        {
            return Ok( await _repositories.ListBasic());
        }

        // api/authors/1
        [Route("{id}")]
        public async Task<IActionResult> GetAuthor(int id)
        {
            return Ok(await _repositories.GetById(id));
        }
    }
}