using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Data;
using Entities.Models;

namespace Presentation.Pages.Lifts
{
    public class CreateModel : PageModel
    {
        private readonly Data.AppDbContext _context;

        public CreateModel(Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Lift Lift { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Lifts.Add(Lift);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}