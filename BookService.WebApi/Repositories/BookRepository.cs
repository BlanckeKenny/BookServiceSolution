using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebApi.DTO;
using BookService.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
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

        public BookDetail GetById(int id)
        {
           return db.Books.Select(a => new BookDetail
            {
                Id = a.Id,
                Title = a.Title,
                AuthorId = a.Author.Id,
                AuthorName = $"{a.Author.FirstName} {a.Author.LastName}",
                FileName = a.FileName,
                ISBN = a.ISBN,
                NumberOfPages = a.NumberOfPages,
                Price = a.Price,
                PublisherId = a.Publisher.Id,
                PublisherName = a.Publisher.Name,
                Year = a.Year
            }).FirstOrDefault(b => b.Id == id);
        }

    }
}
