using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Videoteka.Models
{
    public class Kupac
    {
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        [DisplayName("Prima Obavjestenja")]
        public bool PrimaObavjestenja { get; set; }
        [Required]
        [DisplayName("Datum Rodjenja")]
        public DateTime DatumRodjenja { get; set; }
        [Required]
        [DisplayName("Tip Kupca")]
        public int TipKupcaId { get; set; }
        public TipKupca TipKupca { get; set; }
        [Required]
        [DisplayName("Tip Clanstva")]
        public int TipClanstvaId { get; set; }
        public TipClanstva TipClanstva { get; set; }
    }
}