using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace proiect_medii.Models
{
    public class Companie
    {
        public int ID { get; set; }

        [Display(Name = "Companie Aeriana")]
        public string Nume_companie { get; set; }
        public ICollection<Zbor>? Zboruri { get; set; }
    }
}
