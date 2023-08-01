using System.ComponentModel.DataAnnotations;

namespace Videoteka.Models
{
    public class TipKupca
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Naziv { get; set; }
    }
}