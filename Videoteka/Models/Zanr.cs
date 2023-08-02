using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class Zanr
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Naziv { get; set; }
    }
}