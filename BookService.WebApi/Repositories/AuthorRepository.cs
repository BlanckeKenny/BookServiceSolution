using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebApi.DTO;
using BookService.WebApi.Models;

namespace BookService.WebApi.Repositories
{
    public class AuthorRepository
    {
        private BookServiceContext _context;

        public AuthorRepository(BookServiceContext context)
        {
            _context = context;
        }

        public List<Author> List()
        {
            return _context.Authors.ToList();
        }

        public List<AuthorBasic> GetAuthorBasic()
        {
            return _context.Authors.Select(A => new AuthorBasic
            {
                Id = A.Id,
                Name = $"{A.FirstName} {A.LastName}"
            }).ToList();
        }

        public List<Author> GetById(int id)
        {
            return _context.Authors.Where(a => a.Id == id).ToList();
        }
    }
}
