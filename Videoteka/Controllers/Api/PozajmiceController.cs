using AutoMapper;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using Videoteka.DTOs;
using Videoteka.Models;
using System.Net;

namespace Videoteka.Controllers.Api
{
    public class PozajmiceController : ApiController
    {
        private ApplicationDbContext _context;

        public PozajmiceController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetPozajmice()
        {
            var pozajmiceDTO = _context.Pozajmice
                .Include(p => p.Kupac)
                .Include(p => p.Film)
                .ToList()
                .Select(Mapper.Map<Pozajmica, PozajmicaDTO>);

            return Ok(pozajmiceDTO);
        }

        public IHttpActionResult GetPozajmica(int id)
        {
            var pozajmica = _context.Pozajmice.SingleOrDefault(p => p.Id == id);

            if (pozajmica == null)
                return NotFound();

            return Ok(Mapper.Map<Pozajmica, PozajmicaDTO>(pozajmica));
        }

        [HttpPost]
        public IHttpActionResult CreatePozajmica(PozajmicaDTO pozajmicaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var pozajmica = Mapper.Map<PozajmicaDTO, Pozajmica>(pozajmicaDTO);
            _context.Pozajmice.Add(pozajmica);
            _context.SaveChanges();

            pozajmicaDTO.Id = pozajmica.Id;

            return Created(new System.Uri(Request.RequestUri + "/" + pozajmica.Id), pozajmicaDTO);
        }
    }
}
