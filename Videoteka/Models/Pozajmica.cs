using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Videoteka.Models
{
    public class Pozajmica
    {
        public int Id { get; set; }
        public Kupac Kupac { get; set; }
        [Required]
        [DisplayName("Kupac")]
        public int KupacId { get; set; }
        public Film Film { get; set; }
        [Required]
        [DisplayName("Film")]
        public int FilmId { get; set; }
        [Required]
        [DisplayName("Datum Pozajmice")]
        public DateTime DatumPozajmice { get; set; }
        [DisplayName("Datum Vracanja")]
        public DateTime? DatumVracanja { get; set; }
        [StringLength(255)]
        public string Napomena { get; set; }
    }
}