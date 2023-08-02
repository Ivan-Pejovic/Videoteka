using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult Index()
        {
            return View();
        }

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
    }
}