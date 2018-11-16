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
    public class BookRepository : Repository<Book>
    {

        public BookRepository(BookServiceContext context) : base(context)
        {

        }


        public async Task<List<Book>> GetAllInclusive()
        {
            var booklist = await Db.Books
                .Include(a => a.Author)
                .Include(a => a.Publisher)
                .ToListAsync();
            return booklist;
        }


        public async Task<List<BookBasic>> ListbBasic()
        {
            // returns a list of BookBasic DTO-Items (Id and Title only)
            var bookBasic =  await Db.Books.Select(b => new BookBasic
            {
                Id = b.Id,
                Title = b.Title
            }).ToListAsync();
            return bookBasic;
        }


        public async Task<BookDetail> GetDetailById(int id)
        {
           var bookDetail =  await Db.Books.Select(a => new BookDetail
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
            }).FirstOrDefaultAsync(b => b.Id == id);
            return bookDetail;
        } 
    }
}
