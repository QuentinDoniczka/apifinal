using System.ComponentModel.DataAnnotations;

namespace _27_11_23_asp.Model
{
    public class Groupe
    {
        public int Id { get; set; }
        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }
        public List<ContactGroup> ContactGroup { get; set; }
    }
}
