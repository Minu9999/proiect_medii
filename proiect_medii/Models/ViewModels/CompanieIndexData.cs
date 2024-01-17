using System.Security.Policy;
using proiect_medii.Models;

namespace proiect_medii.Models.ViewModels
{
    public class CompanieIndexData
    {
        public IEnumerable<Companie> Companii { get; set; }
        public IEnumerable<Zbor> Zboruri { get; set; }
    }
}
