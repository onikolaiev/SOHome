using Microsoft.AspNetCore.Identity;

namespace SOHome.Domain.Models
{
    public class User : IdentityUser<long>
    {
        public int Code { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public char Flag { get; set; } = 'A';

        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
