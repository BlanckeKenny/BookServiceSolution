using BookService.WebApi.Models;
using BookService.WebApi.Repositories.Base;

namespace BookService.WebApi.Repositories
{
    public class ReaderRepository : Repository<Reader>
    {
        public ReaderRepository( BookServiceContext context ) : base (context)
        {
            
        }
    }
}
