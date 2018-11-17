using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebApi.DTO
{
    public class BookStatistics
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int RatingCount { get; set; }
        public double ScoreAverage { get; set; }
    }
}
