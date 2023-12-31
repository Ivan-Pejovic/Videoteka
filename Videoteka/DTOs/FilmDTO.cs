﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoteka.Models;

namespace Videoteka.DTOs
{
    public class FilmDTO
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public int ZanrId { get; set; }
        public Zanr Zanr { get; set; }
        public DateTime DatumUnosa { get; set; }
        public DateTime DatumIzdanja { get; set; }
        public int BrojNaStanju { get; set; }
        public int BrojDostupnih { get; set; }
    }
}