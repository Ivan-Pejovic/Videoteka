using System;
using System.Linq;
using System.Web.Mvc;
using Videoteka.Models;
using Videoteka.ViewModels;

namespace Videoteka.Controllers
{
    public class FilmoviController : Controller
    {
        private ApplicationDbContext _context;

        public FilmoviController()
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
            var zanrovi = _context.Zanrovi.ToList();
            var viewModel = new FilmViewModel
            {
                Film = new Film(),
                Zanrovi = zanrovi
            };

            return View("FilmForma", viewModel);
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Izmijeni(int id)
        {
            var film = _context.Filmovi.SingleOrDefault(f => f.Id == id);

            if (film == null)
                return HttpNotFound();

            var viewModel = new FilmViewModel
            {
                Film = film,
                Zanrovi = _context.Zanrovi.ToList()
            };

            return View("FilmForma", viewModel);
        }

        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Film film)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new FilmViewModel
                {
                    Film = film,
                    Zanrovi = _context.Zanrovi.ToList()
                };

                return View("FilmForma", viewModel);
            }

            film.DatumUnosa = DateTime.Now;

            if(film.Id == 0)
            {
                _context.Filmovi.Add(film);
            }
            else
            {
                var filmInDb = _context.Filmovi.Single(f => f.Id == film.Id);

                filmInDb.Naziv = film.Naziv;
                filmInDb.ZanrId = film.ZanrId;
                filmInDb.DatumIzdanja = film.DatumIzdanja;
                filmInDb.BrojNaStanju = film.BrojNaStanju;
                filmInDb.BrojDostupnih = film.BrojDostupnih;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Filmovi");
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            var filmInDb = _context.Filmovi.SingleOrDefault(f => f.Id == id);

            if (filmInDb == null)
                return HttpNotFound();

            _context.Filmovi.Remove(filmInDb);
            _context.SaveChanges();

            return RedirectToAction("Index", "Filmovi");
        }
    }
}