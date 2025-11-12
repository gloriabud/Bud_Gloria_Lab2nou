using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bud_Gloria_Lab2nou.Data;
using Bud_Gloria_Lab2nou.Models;

namespace Bud_Gloria_Lab2nou.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Bud_Gloria_Lab2nou.Data.Bud_Gloria_Lab2nouContext _context;

        public DetailsModel(Bud_Gloria_Lab2nou.Data.Bud_Gloria_Lab2nouContext context)
        {
            _context = context;
        }

        public Category Category { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }
            return Page();
        }
    }
}
