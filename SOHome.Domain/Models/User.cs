using Microsoft.AspNetCore.Identity;

namespace SOHome.Domain.Models
{
    public class User : IdentityUser<long>
    {
        public int? Code { get; set; }
        public char Flag { get; set; } = 'A';

        public long PersonId { get; set; }
        public Person Person { get; set; }
    }
}
