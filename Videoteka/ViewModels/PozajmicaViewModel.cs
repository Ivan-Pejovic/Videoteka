using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoteka.Models;

namespace Videoteka.ViewModels
{
    public class PozajmicaViewModel
    {
        public Pozajmica Pozajmica { get; set; }
        public IEnumerable<Kupac> Kupci { get; set; }
        public IEnumerable<Film> Filmovi { get; set; }
        public bool Nova { get; set; }
    }
}