using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect_medii.Data;
using proiect_medii.Models;

namespace proiect_medii.Pages.Zboruri
{
    public class EditModel : ZborTerminalePageModel
    {
        private readonly proiect_medii.Data.proiect_mediiContext _context;

        public EditModel(proiect_medii.Data.proiect_mediiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Zbor Zbor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Zbor == null)
            {
                return NotFound();
            }
            Zbor = await _context.Zbor
                                 .Include(b => b.Companie)
                                 .Include(b => b.ZborTerminale).ThenInclude(b => b.Terminal)
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(m => m.ID == id);
            if (Zbor == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Zbor);
            ViewData["CompanieID"] = new SelectList(_context.Set<Companie>(), "ID", "Nume_companie");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedTerminale)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zborToUpdate = await _context.Zbor
            .Include(i => i.Companie)
            .Include(i => i.ZborTerminale)
            .ThenInclude(i => i.Terminal)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (zborToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Zbor>(
            zborToUpdate,
            "Zbor",
            i => i.Destinatie,
            i => i.Pret, i => i.Data_zbor, i => i.CompanieID))
            {
                UpdateBookCategories(_context, selectedTerminale, zborToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateBookCategories(_context, selectedTerminale, zborToUpdate);
            PopulateAssignedCategoryData(_context, zborToUpdate);
            return Page();
        }

        private bool ZborExists(int id)
        {
          return (_context.Zbor?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
