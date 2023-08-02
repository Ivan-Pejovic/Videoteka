using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videoteka.DTOs;
using Videoteka.Models;

namespace Videoteka.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Kupac, KupacDTO>();
            Mapper.CreateMap<KupacDTO, Kupac>().ForMember(k => k.Id, opt => opt.Ignore());

            Mapper.CreateMap<TipKupca, TipKupcaDTO>();
            Mapper.CreateMap<TipClanstva, TipClanstvaDTO>();

            Mapper.CreateMap<Film, FilmDTO>();
            Mapper.CreateMap<FilmDTO, Film>().ForMember(k => k.Id, opt => opt.Ignore());
        }
    }
}