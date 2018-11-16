using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.WebApi.Repositories
{
    public class PublisherRepository : Repository<Publisher>
    {

        public PublisherRepository(BookServiceContext context) : base (context)
        {
            
        }
    }
}
