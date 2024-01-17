namespace proiect_medii.Models
{
    public class ZborData
    {
        public IEnumerable<Zbor> Zboruri { get; set; }
        public IEnumerable<Terminal> Terminale { get; set; }
        public IEnumerable<ZborTerminal> ZborTerminale { get; set; }
    }
}
