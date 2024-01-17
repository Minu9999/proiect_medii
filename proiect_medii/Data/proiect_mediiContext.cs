using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using proiect_medii.Models;

namespace proiect_medii.Data
{
    public class proiect_mediiContext : DbContext
    {
        public proiect_mediiContext (DbContextOptions<proiect_mediiContext> options)
            : base(options)
        {
        }

        public DbSet<proiect_medii.Models.Zbor> Zbor { get; set; } = default!;

        public DbSet<proiect_medii.Models.Companie>? Companie { get; set; }

        public DbSet<proiect_medii.Models.Terminal>? Terminal { get; set; }
    }
}
