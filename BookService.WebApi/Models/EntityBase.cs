using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebApi.Models
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        private DateTime? _created;

        public DateTime? Created
        {
            get => _created ?? DateTime.Now;
            set => _created = value ?? DateTime.Now;
        }


    }
}
