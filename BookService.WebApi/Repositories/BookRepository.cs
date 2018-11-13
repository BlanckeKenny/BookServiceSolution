using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebApi.DTO;
using BookService.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookService.WebApi.Repositories
{
    public class BookRepository
    {
        private BookServiceContext db;

        public BookRepository(BookServiceContext context)
        {
            db = context;
        }

        public List<Book> List()
        {
            return db.Books
                .Include(a => a.Author)
                .Include(a => a.Publisher)
                .ToList();
        }

        public List<BookBasic> ListbBasic()
        {
            // returns a list of BookBasic DTO-Items (Id and Title only)
            return db.Books.Select(b => new BookBasic
            {
                Id = b.Id,
                Title = b.Title
            }).ToList();
        }

        public List<Book> GetById(int id)
        {
            return db.Books.Where(a => a.Id == id).ToList();
        }


    }
}
