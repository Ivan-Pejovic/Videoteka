using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Videoteka.Models
{
    public class Film
    {
        public int Id { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        [DisplayName("Zanr")]
        public int ZanrId { get; set; }
        public Zanr Zanr { get; set; }
        [Required]
        [DisplayName("Datum Unosa")]
        public DateTime DatumUnosa { get; set; }
        [Required]
        [DisplayName("Datum Izdanja")]
        public DateTime DatumIzdanja { get; set; }
        [Required]
        [DisplayName("Broj Na Stanju")]
        public int BrojNaStanju { get; set; }
        [Required]
        [DisplayName("Broj Dostupnih")]
        public int BrojDostupnih { get; set; }
    }
}