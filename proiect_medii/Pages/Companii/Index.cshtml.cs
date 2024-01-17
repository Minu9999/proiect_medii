using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using proiect_medii.Data;
using proiect_medii.Models;
using proiect_medii.Models.ViewModels;

namespace proiect_medii.Pages.Companii
{
    public class IndexModel : PageModel
    {
        private readonly proiect_medii.Data.proiect_mediiContext _context;

        public IndexModel(proiect_medii.Data.proiect_mediiContext context)
        {
            _context = context;
        }

        public IList<Companie> Companie { get; set; } = default!;
        public CompanieIndexData CompanieData { get; set; }
        public int CompanieID { get; set; }
        public int ZborID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            CompanieData = new CompanieIndexData();
            CompanieData.Companii = await _context.Companie
            .Include(i => i.Zboruri)
            .OrderBy(i => i.Nume_companie)
            .ToListAsync();
            if (id != null)
            {
                CompanieID = id.Value;
                Companie companie = CompanieData.Companii
                .Where(i => i.ID == id.Value).Single();
                CompanieData.Zboruri = companie.Zboruri;
            }
        }
    }
}
