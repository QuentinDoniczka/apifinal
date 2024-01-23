using _27_11_23_asp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace _27_11_23_asp.Pages.Contacts
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public bool FiltredGroup { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool FiltredPro { get; set; }

        private readonly Data.ApplicationDbContext _context;

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 5;

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; }
        [BindProperty(SupportsGet = true)]
        public bool reverse { get; set; } = false;
        public void Paginate(int count)
        {
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
        }
        public IndexModel(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Contact> Contact { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Contact != null)
            {
                var query = _context.Contact
                    .Include(c=> c.ContactGroup)
                    .ThenInclude(cg => cg.Groupe)
                    .AsQueryable();

                if (FiltredGroup)
                {
                    /*query = query.Where(c => c.GroupeId == null);*/
                    query = query.Where(c => c.ContactGroup.Any(cg => cg.Groupe.Name == null)); //TODOASK
                }
                if (FiltredPro)
                {
                    query = query.Where(c => c.IsPro);
                }
                if (SortOrder != null)
                {
                    query = query.OrderByDescending(x => EF.Property<object>(x, SortOrder));
                }

                if (reverse)
                {
                    query = query.Reverse();
                }
                var count = await query.CountAsync();

                TotalPages = (int)Math.Ceiling(count / (double)PageSize);
                PageIndex = Math.Max(1, Math.Min(PageIndex, TotalPages));

                Contact = await query
                    .Skip((PageIndex - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();
            }
        }
    }
}
