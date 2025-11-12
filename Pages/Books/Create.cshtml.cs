using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bud_Gloria_Lab2nou.Data;
using Bud_Gloria_Lab2nou.Models;

namespace Bud_Gloria_Lab2nou.Pages.Books
{
    public class CreateModel : BookCategoriesPageModel
    {
        private readonly Bud_Gloria_Lab2nou.Data.Bud_Gloria_Lab2nouContext _context;

        public CreateModel(Bud_Gloria_Lab2nou.Data.Bud_Gloria_Lab2nouContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var book = new Book();
            book.BookCategories = new List<BookCategory>();

            
            PopulateAssignedCategoryData(_context, book);

            
            ViewData["AuthorID"] = new SelectList(_context.Author, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Publisher, "ID", "PublisherName");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
           
            var newBook = new Book();
            if (selectedCategories != null)
            {
                newBook.BookCategories = new List<BookCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new BookCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newBook.BookCategories.Add(catToAdd);
                }
            }

            
            if (await TryUpdateModelAsync<Book>(
                newBook,
                "Book", 
                i => i.Title, i => i.AuthorID,
                i => i.Price, i => i.PublishingDate, i => i.PublisherID))
            {
                _context.Book.Add(newBook);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

           
            PopulateAssignedCategoryData(_context, newBook);
            return Page();
        }
    }
}
