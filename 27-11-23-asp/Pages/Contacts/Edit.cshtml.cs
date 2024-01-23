using _27_11_23_asp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace _27_11_23_asp.Pages.Contacts
{
    public class EditModel : PageModel
    {
        private readonly _27_11_23_asp.Data.ApplicationDbContext _context;

        [BindProperty]
        public List<int> SelectedGroupeIds { get; set; }
        public SelectList GroupeList { get; set; }
     
        public EditModel(_27_11_23_asp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contact Contact { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }

            var contact =  _context.Contact
                .Include(c => c.ContactGroup)
                .ThenInclude(cg => cg.Groupe)
                .FirstOrDefault(c => c.Id == id);

            if (contact == null)
            {
                return NotFound();
            }
            SelectedGroupeIds = contact.ContactGroup.Select(x => x.GroupeId).ToList();
            GroupeList = new SelectList(_context.Groupe, nameof(Groupe.Id), nameof(Groupe.Name));
            Contact = contact;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(Contact.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ContactExists(int id)
        {
          return (_context.Contact?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
