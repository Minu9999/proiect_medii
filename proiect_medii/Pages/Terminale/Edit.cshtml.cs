﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proiect_medii.Data;
using proiect_medii.Models;

namespace proiect_medii.Pages.Terminale
{
    public class EditModel : PageModel
    {
        private readonly proiect_medii.Data.proiect_mediiContext _context;

        public EditModel(proiect_medii.Data.proiect_mediiContext context)
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

            var terminal =  await _context.Terminal.FirstOrDefaultAsync(m => m.ID == id);
            if (terminal == null)
            {
                return NotFound();
            }
            Terminal = terminal;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Terminal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TerminalExists(Terminal.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TerminalExists(int id)
        {
          return (_context.Terminal?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
