using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _27_11_23_asp.Data;
using _27_11_23_asp.Model;

namespace _27_11_23_asp.Pages.Groupes
{
    public class DetailsModel : PageModel
    {
        private readonly _27_11_23_asp.Data.ApplicationDbContext _context;

        public DetailsModel(_27_11_23_asp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Groupe Groupe { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Groupe == null)
            {
                return NotFound();
            }

            var groupe = await _context.Groupe.FirstOrDefaultAsync(m => m.Id == id);
            if (groupe == null)
            {
                return NotFound();
            }
            else 
            {
                Groupe = groupe;
            }
            return Page();
        }
    }
}
