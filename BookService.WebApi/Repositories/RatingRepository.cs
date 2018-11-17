using System.Collections.Generic;
using System.Threading.Tasks;
using BookService.WebApi.Models;
using BookService.WebApi.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace BookService.WebApi.Repositories
{
    public class RatingRepository : Repository<Rating>
    {
        public RatingRepository(BookServiceContext context) : base (context)
        {
            
        }
        public async Task<List<Rating>> GetAllInclusive()
        {
            return await GetAll()
                .Include(a => a.Reader)
                .Include(a => a.Book)
                .ToListAsync();
        }
    }
}
