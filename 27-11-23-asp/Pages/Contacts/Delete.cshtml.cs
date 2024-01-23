using _27_11_23_asp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _27_11_23_asp.Pages.Contacts
{
    public class DeleteModel : PageModel
    {
        private readonly _27_11_23_asp.Data.ApplicationDbContext _context;

        public DeleteModel(_27_11_23_asp.Data.ApplicationDbContext context)
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

            var contact = await _context.Contact.FirstOrDefaultAsync(m => m.Id == id);

            if (contact == null)
            {
                return NotFound();
            }
            else 
            {
                Contact = contact;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Contact == null)
            {
                return NotFound();
            }
            var contact = await _context.Contact.FindAsync(id);

            if (contact != null)
            {
                Contact = contact;
                _context.Contact.Remove(Contact);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
