using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebApi.Models;
using BookService.WebApi.Repositories;
using Microsoft.AspNetCore.Http;
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