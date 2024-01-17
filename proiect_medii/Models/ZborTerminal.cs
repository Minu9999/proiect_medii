namespace proiect_medii.Models
{
    public class ZborTerminal
    {
        public int ID { get; set; }
        public int ZborID { get; set; }
        public Zbor Zbor { get; set; }
        public int TerminalID { get; set; }
        public Terminal Terminal { get; set; }
    }
}
