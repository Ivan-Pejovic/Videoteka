using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoteka.Models;

namespace Videoteka.ViewModels
{
    public class KupacViewModel
    {
        public Kupac Kupac { get; set; }
        public IEnumerable<TipKupca> TipoviKupaca { get; set; }
        public IEnumerable<TipClanstva> TipoviClanstva { get; set; }
    }
}