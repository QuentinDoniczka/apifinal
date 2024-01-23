using _27_11_23_asp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _27_11_23_asp.Pages.Contacts
{
    public class DetailsModel : PageModel
    {
        private readonly _27_11_23_asp.Data.ApplicationDbContext _context;

        public DetailsModel(_27_11_23_asp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
