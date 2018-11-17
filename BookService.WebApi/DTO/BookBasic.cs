using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebApi.Models;

namespace BookService.WebApi.DTO
{
    public class BookBasic
    {
        public int Id { get; set; }
        public string Title { get; set; }

       /* public string AuthorId { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public string PublisherId { get; set; }
        public string PublisherName { get; set; }
        public ICollection<Rating> Ratings { get; set; }*/
    }
}
