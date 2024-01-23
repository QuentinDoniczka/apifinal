using _27_11_23_asp.Migrations;
using _27_11_23_asp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ContactGroup = _27_11_23_asp.Model.ContactGroup;

namespace _27_11_23_asp.Pages.Contacts
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public int NumberOfContacts { get; set; }

        private readonly _27_11_23_asp.Data.ApplicationDbContext _context;
        public SelectList GroupList { get; set; }
        [BindProperty]
        public List<int> SelectedGroupIds { get; set; }
        [BindProperty]
        public Contact Contact { get; set; }
        public CreateModel(_27_11_23_asp.Data.ApplicationDbContext context)
        {
            _context = context;
            GroupList = new SelectList(_context.Groupe, "Id", "Name");
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            List<ContactGroup> listContactGroups = new List<ContactGroup>();
            foreach (var groupId in SelectedGroupIds)
            {
                ContactGroup contactGroup = new Model.ContactGroup()
                {
                    ContactId = Contact.Id,
                    GroupeId = groupId
                };
                listContactGroups.Add(contactGroup);
            }

            Contact.ContactGroup = listContactGroups;
            _context.Add(Contact);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }


        public async Task<IActionResult> OnPostGenerateAsync()
        {
            Random random = new();
            List<int> groupIds = _context.Groupe.Select(g => g.Id).ToList();

            for (int i = 0; i < NumberOfContacts; i++)
            {
                int? groupId = null;
                if (groupIds.Any() && random.Next(4) != 0) // 75% de chance dassigner un groupe
                {
                    groupId = groupIds[random.Next(groupIds.Count)];
                }
                Contact newContact = new Contact
                {
                    FirstName = GenerateRandomString(random, 2, 20)+i,
                    LastName = GenerateRandomString(random, 2, 20)+i,
                    Email = $"user{i}@example.com",
                    IsPro = random.Next(2) == 0,
                    /*GroupeId = groupId,*/
                };

                _context.Contact.Add(newContact);
            }
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
        private string GenerateRandomString(Random random, int minLength, int maxLength)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int length = random.Next(minLength, maxLength + 1);
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
