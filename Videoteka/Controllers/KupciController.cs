using System;
using System.Linq;
using System.Web.Mvc;
using Videoteka.Models;
using Videoteka.ViewModels;

namespace Videoteka.Controllers
{
    public class KupciController : Controller
    {
        private ApplicationDbContext _context;

        public KupciController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Novi()
        {
            var tipoviKupca = _context.TipoviKupaca.ToList();
            var tipoviClanstva = _context.TipoviClanstva.ToList();
            var viewModel = new KupacViewModel
            {
                Kupac = new Kupac(),
                TipoviKupaca = tipoviKupca,
                TipoviClanstva = tipoviClanstva
            };

            return View("KupacForma", viewModel);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Izmijeni(int id)
        {
            var kupac = _context.Kupci.SingleOrDefault(k => k.Id == id);

            if(kupac == null)
                return HttpNotFound();

            var viewModel = new KupacViewModel
            {
                Kupac = kupac,
                TipoviKupaca = _context.TipoviKupaca.ToList(),
                TipoviClanstva = _context.TipoviClanstva.ToList()
            };

            return View("KupacForma", viewModel);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Kupac kupac)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new KupacViewModel
                {
                    Kupac = kupac,
                    TipoviKupaca = _context.TipoviKupaca.ToList(),
                    TipoviClanstva = _context.TipoviClanstva.ToList()
                };

                return View("KupacForma", viewModel);
            }

            if(kupac.Id == 0)
            {
                _context.Kupci.Add(kupac);
            }
            else
            {
                var kupacInDb = _context.Kupci.Single(k => k.Id == kupac.Id);

                kupacInDb.Ime = kupac.Ime;
                kupacInDb.PrimaObavjestenja = kupac.PrimaObavjestenja;
                kupacInDb.DatumRodjenja = kupac.DatumRodjenja;
                kupacInDb.TipKupcaId = kupac.TipKupcaId;
                kupacInDb.TipClanstvaId = kupac.TipClanstvaId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Kupci");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            var kupacInDb = _context.Kupci.SingleOrDefault(k => k.Id == id);

            if (kupacInDb == null)
                return HttpNotFound();

            _context.Kupci.Remove(kupacInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Kupci");
        }
    }
}