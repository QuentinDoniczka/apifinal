using System.ComponentModel.DataAnnotations;

namespace _27_11_23_asp.Model
{
    public class Contact
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "my error message MinimumLength = 2 et maximumLength = 50")]
        public string? LastName { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string? FirstName { get; set; }
        [StringLength(250, MinimumLength = 5)]
        public string? Email { get; set; }
        public bool IsPro { get; set; }
        public List<ContactGroup>? ContactGroup { get; set; }
    }
}

