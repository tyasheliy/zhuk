namespace zhuk.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public DateTime Date { get; set; }
    }
}
