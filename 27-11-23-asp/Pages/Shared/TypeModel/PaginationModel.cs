using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _27_11_23_asp.Pages.Shared.TypeModel
{
    public class PaginationModel 
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
    }
}
