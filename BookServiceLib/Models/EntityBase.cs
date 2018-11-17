using System;

namespace BookServiceLib.Models
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
