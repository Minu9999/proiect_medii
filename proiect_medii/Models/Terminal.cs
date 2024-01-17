using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace proiect_medii.Models
{
    public class Terminal
    {
        public int ID { get; set; }

        [Display(Name = "Nume terminal")]
        public string Nume_terminal { get; set; }
        public ICollection<ZborTerminal>? ZborTerminale { get; set; }
    }
}
