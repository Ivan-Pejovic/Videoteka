using AutoMapper;
using System.Linq;
using System.Data.Entity;
using System.Web.Http;
using Videoteka.DTOs;
using Videoteka.Models;
using System.Net;

namespace Videoteka.Controllers.Api
{
    public class KupciController : ApiController
    {
        private ApplicationDbContext _context;

        public KupciController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetKupci()
        {
            var kupciDTO = _context.Kupci
                .Include(k => k.TipKupca)
                .Include(k => k.TipClanstva)
                .ToList()
                .Select(Mapper.Map<Kupac, KupacDTO>);

            return Ok(kupciDTO);
        }

        public IHttpActionResult GetKupac(int id)
        {
            var kupac = _context.Kupci.SingleOrDefault(k => k.Id == id);

            if (kupac == null)
                return NotFound();

            return Ok(Mapper.Map<Kupac, KupacDTO>(kupac));
        }

        [HttpPost]
        public IHttpActionResult CreateKupac(KupacDTO kupacDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var kupac = Mapper.Map<KupacDTO, Kupac>(kupacDTO);
            _context.Kupci.Add(kupac);
            _context.SaveChanges();

            kupacDTO.Id = kupac.Id;

            return Created(new System.Uri(Request.RequestUri + "/" + kupac.Id), kupacDTO);
        }

        [HttpPut]
        public void UpdateKupac(int id, KupacDTO kupacDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var kupacInDb = _context.Kupci.SingleOrDefault(k => k.Id == id);

            if (kupacInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(kupacDTO, kupacInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteKupac(int id)
        {
            var kupacInDb = _context.Kupci.SingleOrDefault(k => k.Id == id);

            if (kupacInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Kupci.Remove(kupacInDb);
            _context.SaveChanges();
        }
    }
}
