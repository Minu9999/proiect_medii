using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_medii.Data;
using proiect_medii.Models;

namespace proiect_medii.Pages.Terminale
{
    public class DeleteModel : PageModel
    {
        private readonly proiect_medii.Data.proiect_mediiContext _context;

        public DeleteModel(proiect_medii.Data.proiect_mediiContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Terminal Terminal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Terminal == null)
            {
                return NotFound();
            }

            var terminal = await _context.Terminal.FirstOrDefaultAsync(m => m.ID == id);

            if (terminal == null)
            {
                return NotFound();
            }
            else 
            {
                Terminal = terminal;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Terminal == null)
            {
                return NotFound();
            }
            var terminal = await _context.Terminal.FindAsync(id);

            if (terminal != null)
            {
                Terminal = terminal;
                _context.Terminal.Remove(Terminal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
