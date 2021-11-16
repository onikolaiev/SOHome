namespace SOHome.Domain.Models
{
    public class User
    {
        public long Id { get; set; }
        public int Code { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public char Flag { get; set; } = 'A';

        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
