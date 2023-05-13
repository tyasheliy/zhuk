using System.Data;

namespace zhuk.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
