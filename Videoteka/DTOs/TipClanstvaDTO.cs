using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.DTOs
{
    public class TipClanstvaDTO
    {
        public int Id { get; set; }
        [Required]
        public int Clanarina { get; set; }
        [Required]
        public int TrajanjeMjeseci { get; set; }
        [Required]
        public int ProcenatPopusta { get; set; }
        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }
    }
}