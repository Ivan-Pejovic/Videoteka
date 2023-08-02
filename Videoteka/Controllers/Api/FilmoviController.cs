using AutoMapper;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using Videoteka.DTOs;
using Videoteka.Models;
using System.Net;

namespace Videoteka.Controllers.Api
{
    public class FilmoviController : ApiController
    {
        private ApplicationDbContext _context;

        public FilmoviController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetFilmovi()
        {
            var filmoviDTO = _context.Filmovi
                .Include(f => f.Zanr)
                .ToList()
                .Select(Mapper.Map<Film, FilmDTO>);

            return Ok(filmoviDTO);
        }
    }
}
