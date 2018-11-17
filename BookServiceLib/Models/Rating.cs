namespace BookServiceLib.Models
{
    public class Rating : EntityBase
    {
        public int Score { get; set; }
        public int ReaderId { get; set; }
        public Reader Reader { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }  

    }
}
