using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebApi.Models;

namespace BookService.WebApi.Repositories
{
    public class PublisherRepository
    {
        private BookServiceContext _context;

        public PublisherRepository(BookServiceContext context)
        {
            _context = context;
        }

        public List<Publisher> List()
        {
            return _context.Publishers.ToList();
        }

        public List<Publisher> GetById(int id)
        {
            return _context.Publishers.Where(a => a.Id == id).ToList();
        }
    }
}
