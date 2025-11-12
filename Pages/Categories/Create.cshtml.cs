using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bud_Gloria_Lab2nou.Data;
using Bud_Gloria_Lab2nou.Models;

namespace Bud_Gloria_Lab2nou.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Bud_Gloria_Lab2nou.Data.Bud_Gloria_Lab2nouContext _context;

        public CreateModel(Bud_Gloria_Lab2nou.Data.Bud_Gloria_Lab2nouContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
