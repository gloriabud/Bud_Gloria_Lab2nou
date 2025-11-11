using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bud_Gloria_Lab2nou.Data;
using Bud_Gloria_Lab2nou.Models;

namespace Bud_Gloria_Lab2nou.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Bud_Gloria_Lab2nou.Data.Bud_Gloria_Lab2nouContext _context;

        public IndexModel(Bud_Gloria_Lab2nou.Data.Bud_Gloria_Lab2nouContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
        }
    }
}
