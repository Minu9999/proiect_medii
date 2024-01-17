﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly proiect_medii.Data.proiect_mediiContext _context;

        public DetailsModel(proiect_medii.Data.proiect_mediiContext context)
        {
            _context = context;
        }

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
    }
}
