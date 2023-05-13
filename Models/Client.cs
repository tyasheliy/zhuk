namespace zhuk.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string? Middlename { get; set; }
        public string Phone { get; set; }
    }
}
