using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebApi.Models
{
    public class Reader: EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
    }
}
