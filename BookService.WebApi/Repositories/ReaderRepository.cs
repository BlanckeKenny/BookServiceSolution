using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebApi.Models;

namespace BookService.WebApi.Repositories
{
    public class ReaderRepository : Repository<Reader>
    {
        public ReaderRepository( BookServiceContext context ) : base (context)
        {
            
        }
    }
}
