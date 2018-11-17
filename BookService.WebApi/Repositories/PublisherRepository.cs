using BookService.WebApi.Models;
using BookService.WebApi.Repositories.Base;


namespace BookService.WebApi.Repositories
{
    public class PublisherRepository : Repository<Publisher>
    {

        public PublisherRepository(BookServiceContext context) : base (context)
        {
            
        }
    }
}
