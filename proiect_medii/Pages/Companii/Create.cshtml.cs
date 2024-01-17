using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect_medii.Data;
using proiect_medii.Models;

namespace proiect_medii.Pages.Companii
{
    public class CreateModel : PageModel
    {
        private readonly proiect_medii.Data.proiect_mediiContext _context;

        public CreateModel(proiect_medii.Data.proiect_mediiContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Companie Companie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Companie == null || Companie == null)
            {
                return Page();
            }

            _context.Companie.Add(Companie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
