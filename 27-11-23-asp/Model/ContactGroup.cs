namespace _27_11_23_asp.Model
{
    // dotnet ef migrations add TODO
    // dotnet ef database update
    public class ContactGroup
    {
        public int ContactId { get; set; }
        public int GroupeId { get; set; }

        public Contact Contact { get; set; }
        public Groupe Groupe { get; set; }
    }
}
