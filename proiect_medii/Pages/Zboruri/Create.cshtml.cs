using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using proiect_medii.Data;
using proiect_medii.Models;

namespace proiect_medii.Pages.Zboruri
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
            ViewData["CompanieID"] = new SelectList(_context.Set<Companie>(), "ID", "Nume_companie");

            return Page();
        }

        [BindProperty]
        public Zbor Zbor { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Zbor == null || Zbor == null)
            {
                return Page();
            }

            _context.Zbor.Add(Zbor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
