using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoteka.Models;

namespace Videoteka.DTOs
{
    public class KupacDTO
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public bool PrimaObavjestenja { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int TipKupcaId { get; set; }
        public TipKupcaDTO TipKupca { get; set; }
        public int TipClanstvaId { get; set; }
        public TipClanstvaDTO TipClanstva { get; set; }
    }
}