using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.DTOs
{
    public class TipKupcaDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Naziv { get; set; }
    }
}