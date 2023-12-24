using Demo.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Demo.ModelView
{
    public class ProductViewModel
    {
        public IEnumerable<Product> products { get; set; }
        //public PaginatedList pager { get; set; }
    }
}
