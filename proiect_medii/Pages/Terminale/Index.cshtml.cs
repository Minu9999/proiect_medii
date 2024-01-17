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
    public class IndexModel : PageModel
    {
        private readonly proiect_medii.Data.proiect_mediiContext _context;

        public IndexModel(proiect_medii.Data.proiect_mediiContext context)
        {
            _context = context;
        }

        public IList<Terminal> Terminal { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Terminal != null)
            {
                Terminal = await _context.Terminal.ToListAsync();
            }
        }
    }
}
