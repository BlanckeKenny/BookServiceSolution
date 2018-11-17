using System.Collections.Generic;

namespace BookServiceLib.Models
{
    public class Book : EntityBase
    {
        public string Title { get; set; }
        public string Isbn { get; set; }
        public int NumberOfPages { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public string FileName { get; set; }
        public decimal  Price { get; set; }
        public int  Year { get; set; }  
        public ICollection<Rating> Ratings { get; set; }

    }
}
