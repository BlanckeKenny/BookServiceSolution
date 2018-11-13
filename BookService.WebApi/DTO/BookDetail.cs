using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebApi.DTO
{
    public class BookDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "#")]
        public int NumberOfPages { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public string FileName { get; set; }
    }
}
