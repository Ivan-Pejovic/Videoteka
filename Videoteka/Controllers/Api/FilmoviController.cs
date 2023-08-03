using AutoMapper;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using Videoteka.DTOs;
using Videoteka.Models;

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
        public IHttpActionResult GetFilm(int id)
        {
            var film = _context.Filmovi.SingleOrDefault(f => f.Id == id);

            if (film == null)
                return NotFound();

            return Ok(Mapper.Map<Film, FilmDTO>(film));
        }

        [HttpPost]
        public IHttpActionResult CreateFilm(FilmDTO filmDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var film = Mapper.Map<FilmDTO, Film>(filmDTO);
            _context.Filmovi.Add(film);
            _context.SaveChanges();

            filmDTO.Id = film.Id;

            return Created(new System.Uri(Request.RequestUri + "/" + film.Id), filmDTO);
        }

        [HttpPut]
        public IHttpActionResult UpdateFilm(int id, FilmDTO filmDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var filmInDb = _context.Filmovi.SingleOrDefault(f => f.Id == id);

            if (filmInDb == null)
                return NotFound();

            Mapper.Map(filmDTO, filmInDb);

            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteFilm(int id)
        {
            var filmInDb = _context.Filmovi.SingleOrDefault(f => f.Id == id);

            if (filmInDb == null)
                return NotFound();

            _context.Filmovi.Remove(filmInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
