using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebApi.Models
{
    public class Publisher : EntityBase
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
