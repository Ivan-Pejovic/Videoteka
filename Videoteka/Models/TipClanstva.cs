using System.ComponentModel.DataAnnotations;

namespace Videoteka.Models
{
    public class TipClanstva
    {
        public int Id { get; set; }
        [Required]
        public int Clanarina { get; set; }
        [Required]
        public int TrajanjeMjeseci { get; set; }
        [Required]
        public int ProcenatPopusta { get; set; }
        [Required]
        [StringLength(100)]
        public string Naziv { get; set; }
    }
}