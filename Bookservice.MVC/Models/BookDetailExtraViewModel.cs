using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookServiceLib.DTO;

namespace Bookservice.MVC.Models
{
    public class BookDetailExtraViewModel
    {
        public BookDetail BookDetail { get; set; }
        public string AuthorJoke { get; set; }
        public string BookSummary { get; set; }
    }
}
