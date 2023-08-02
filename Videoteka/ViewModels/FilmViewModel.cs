using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoteka.Models;

namespace Videoteka.ViewModels
{
    public class FilmViewModel
    {
        public Film Film { get; set; }
        public IEnumerable<Zanr> Zanrovi { get; set; }
    }
}