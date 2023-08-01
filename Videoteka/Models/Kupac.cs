using System;

namespace Videoteka.Models
{
    public class Kupac
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public bool PrimaObavjestenja { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int TipKupcaId { get; set; }
        public TipKupca TipKupca { get; set; }
        public int TipClanstvaId { get; set; }
        public TipClanstva TipClanstva { get; set; }
    }
}