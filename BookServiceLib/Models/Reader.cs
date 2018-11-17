using System.Collections.Generic;

namespace BookServiceLib.Models
{
    public class Reader: EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<Rating> Ratings { get; set; }
    }
}
