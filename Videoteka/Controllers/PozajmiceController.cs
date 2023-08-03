using System;
using System.Linq;
using System.Web.Mvc;
using Videoteka.Models;
using Videoteka.ViewModels;

namespace Videoteka.Controllers
{
    public class PozajmiceController : Controller
    {
        private ApplicationDbContext _context;

        public PozajmiceController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Izmijeni(int id)
        {
            var pozajmica = _context.Pozajmice.SingleOrDefault(p => p.Id == id);

            if(pozajmica == null)
                return HttpNotFound();

            var viewModel = new PozajmicaViewModel
            {
                Pozajmica = pozajmica,
                Kupci = _context.Kupci,
                Filmovi = _context.Filmovi,
                Nova = false
            };

            return View("PozajmicaForma", viewModel);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Nova()
        {
            var viewModel = new PozajmicaViewModel
            {
                Pozajmica = new Pozajmica(),
                Kupci = _context.Kupci,
                Filmovi = _context.Filmovi,
                Nova = true
            };

            return View("PozajmicaForma", viewModel);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Pozajmica pozajmica)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new PozajmicaViewModel
                {
                    Pozajmica = pozajmica,
                    Kupci = _context.Kupci,
                    Filmovi = _context.Filmovi
                };

                return View("PozajmicaForma", viewModel);
            }

            if (pozajmica.Id == 0)
            {
                pozajmica.DatumPozajmice = DateTime.Now;
                _context.Pozajmice.Add(pozajmica);
            }
            else
            {
                var pozajmicaInDb = _context.Pozajmice.Single(p => p.Id == pozajmica.Id);

                pozajmicaInDb.KupacId = pozajmica.KupacId;
                pozajmicaInDb.FilmId = pozajmica.FilmId;

                if (pozajmica.DatumVracanja == null)
                    pozajmicaInDb.DatumPozajmice = DateTime.Now;
                else
                    pozajmicaInDb.DatumPozajmice = pozajmica.DatumPozajmice;

                pozajmicaInDb.DatumVracanja = pozajmica.DatumVracanja;
                pozajmicaInDb.Napomena = pozajmica.Napomena;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Pozajmice");
        }
    }
}