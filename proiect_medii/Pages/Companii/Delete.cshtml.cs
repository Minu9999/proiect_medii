using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_medii.Data;
using proiect_medii.Models;

namespace proiect_medii.Pages.Companii
{
    public class DeleteModel : PageModel
    {
        private readonly proiect_medii.Data.proiect_mediiContext _context;

        public DeleteModel(proiect_medii.Data.proiect_mediiContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Companie Companie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Companie == null)
            {
                return NotFound();
            }

            var companie = await _context.Companie.FirstOrDefaultAsync(m => m.ID == id);

            if (companie == null)
            {
                return NotFound();
            }
            else 
            {
                Companie = companie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Companie == null)
            {
                return NotFound();
            }
            var companie = await _context.Companie.FindAsync(id);

            if (companie != null)
            {
                Companie = companie;
                _context.Companie.Remove(Companie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
