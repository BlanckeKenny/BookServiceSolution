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
        private AuthorRepository _repositories;

        public AuthorsController(AuthorRepository repositories)
        {
            this._repositories = repositories;
        }

        // api/authors
        public IActionResult GetAuthors()
        {
            return Ok(_repositories.List());
        }

        // api/authors/basic
        [Route("Basic")]
        public IActionResult GetAuthorBasic()
        {
            return Ok(_repositories.GetAuthorBasic());
        }

        // api/authors/1
        [Route("{id}")]
        public IActionResult GetAuthor(int id)
        {
            return Ok(_repositories.GetById(id));
        }
    }
}