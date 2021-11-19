using System.ComponentModel.DataAnnotations;

namespace SOHome.Domain.Models
{
    public class Person
    {
        public long Id { get; set; }
        public int? Code { get; set; }
        [Required]
        public string Document { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string? StreetName { get; set; }
        public string? StreetNumber { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
    }
}
