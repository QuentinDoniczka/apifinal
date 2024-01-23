using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _27_11_23_asp.Data;
using _27_11_23_asp.Model;

namespace _27_11_23_asp.Pages.Groupes
{
    public class EditModel : PageModel
    {
        private readonly _27_11_23_asp.Data.ApplicationDbContext _context;

        public EditModel(_27_11_23_asp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Groupe Groupe { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Groupe == null)
            {
                return NotFound();
            }

            var groupe =  await _context.Groupe.FirstOrDefaultAsync(m => m.Id == id);
            if (groupe == null)
            {
                return NotFound();
            }
            Groupe = groupe;
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

            _context.Attach(Groupe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupeExists(Groupe.Id))
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

        private bool GroupeExists(int id)
        {
          return (_context.Groupe?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
