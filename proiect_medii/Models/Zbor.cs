using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace proiect_medii.Models
{
    public class Zbor
    {
        public int ID { get; set; }
        public string Destinatie { get; set; }

        [Display(Name = "Companie Aeriana")]
        public string Companie_Aeriana { get; set; }
        
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [Display(Name = "Data zbor")]
        [DataType(DataType.Date)]
        public DateTime Data_zbor { get; set; }

        public int? CompanieID { get; set; }
        public Companie? Companie { get; set; }
        public ICollection<ZborTerminal>? ZborTerminale { get; set; }
    }
}
