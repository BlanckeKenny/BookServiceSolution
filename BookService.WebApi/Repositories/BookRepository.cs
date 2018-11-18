using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookService.WebApi.Models;
using BookService.WebApi.Repositories.Base;
using BookServiceLib.DTO;
using BookServiceLib.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.WebApi.Repositories
{
    public class BookRepository : MappingRepository<Book>
    {

        public BookRepository(BookServiceContext context, IMapper mapper) : base(context, mapper)
        {

        }


        public async Task<List<Book>> GetAllInclusive()
        {
            return await GetAll()
                .Include(a => a.Author)
                .Include(a => a.Publisher)
                .ToListAsync();
        }


        public async Task<List<BookBasic>> ListbBasic()
        {
            // returns a list of BookBasic DTO-Items (Id and Title only) using automapper and sort by title

            return await Db.Books
                .ProjectTo<BookBasic>(Mapper.ConfigurationProvider)
                .OrderBy(b => b.Title)
                .ToListAsync();
        }


        public async Task<BookDetail> GetDetailById(int id)
        {
            return Mapper.Map<BookDetail>(
                await Db.Books
                    .Include(b => b.Author)
                    .Include(a => a.Publisher)
                    .FirstOrDefaultAsync(a => a.Id == id)
            );
        }

        public async Task<List<BookStatistics>> GetStatistics()
        {
            return await Db.Books
                .Include(b => b.Ratings)
                .Where(b => b.Ratings.Count > 0)
                .ProjectTo<BookStatistics>(Mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
