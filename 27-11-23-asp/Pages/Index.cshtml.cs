using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _27_11_23_asp.Data;
using _27_11_23_asp.Model;

namespace _27_11_23_asp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly _27_11_23_asp.Data.ApplicationDbContext _context;

        public IndexModel(_27_11_23_asp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Contact> Contact { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Contact != null)
            {
                Contact = await _context.Contact.ToListAsync();
            }
        }
    }
}
